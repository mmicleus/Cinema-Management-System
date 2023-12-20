using BlazorCinemaMS.Server.Helper.Utility;
using BlazorCinemaMS.Shared.Authentication;
using BlazorCinemaMS.Shared.DTOs;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Humanizer;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorCinemaMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static AppUser user = new AppUser();
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUtilityService _utility;
        private readonly IBookingRepository _bookingRepo;

        public AuthController(IConfiguration configuration,
            UserManager<AppUser> userManager,
            IUtilityService utility,
            IBookingRepository bookingRepo)
        {
            _configuration = configuration;
            _userManager = userManager;
            _utility = utility;
            _bookingRepo = bookingRepo;
        }


        //[HttpPost]
        //public async Task<ActionResult<string>> Login(UserLoginDTO request)
        //{
        //    string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
        //    return token;
        //}

        public async Task<ActionResult<string>> CreateNewUser(UserJoinDTO dto)
        {

            AppUser user = new AppUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                NameOnCard = "",
                CardNumber = "",
                ExpMonth = "",
                ExpYear = "",
                CVV = ""
            };


            IdentityResult result1;

            try
            {
                result1 = await _userManager.CreateAsync(user, dto.Password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //  Console.WriteLine(result1.Errors);


            if (!result1.Succeeded) return BadRequest(String.Join("\n", result1.Errors.Select(e => e.Description)));


            IdentityResult result2;


            try
            {
                result2 = await _userManager.AddToRoleAsync(user, "Member");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (!result2.Succeeded) { 
                await _userManager.DeleteAsync(user);
                return BadRequest(String.Join("\n", result2.Errors.Select(e => e.Description)));
            }


            return Ok("Registration succeeded!");
        }


        
        [HttpGet("user/{email}")]
        [Authorize]
        public async Task<AppUserDTO> GetUser(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            AppUserDTO userDTO = _utility.GetAppUserDTOFromUser(user);

            return userDTO;
        }


        [HttpGet("userBookings")]
        [Authorize]
        public async Task<IEnumerable<BookingDTO>> GetBookingsByUser()
        {
            var result = _utility.GetAuthorizationToken(Request.Headers);

            Console.Write(result);

            JwtSecurityToken secToken = _utility.TestJwtSecurityTokenHandler(result) as JwtSecurityToken;
            

            //Claim claim = secToken.Claims.First(claim => claim.Type == "emailaddress");
        


            string? email = _utility.GetEmailFromClaims(secToken.Claims);

            AppUser user = await _userManager.FindByEmailAsync(email);


            IEnumerable<Booking> bookings = await _bookingRepo.GetBookingsByUser(user.Id);

            return bookings.Select(b => _utility.GetBookingDTOFromBooking(b)).ToList();

            
        }





        [HttpPost("join")]
		public async Task<ActionResult<string>> Join(UserJoinDTO request)
		{
            //AppUser user = await _userManager.FindByEmailAsync(request.Email);

            if (await _userManager.FindByEmailAsync(request.Email) != null) return BadRequest("User with the same email already exists!");

            if (await _userManager.FindByNameAsync(request.Username) != null) return BadRequest("Username already taken!");
            

            return await CreateNewUser(request);
		}



		[HttpPost("login")]
		public async Task<ActionResult<UserAndTokenDTO>> Login(UserLoginDTO request)
		{
            AppUser user = await _userManager.FindByEmailAsync(request.Username);

            if (user == null)
            {
                return BadRequest(new UserAndTokenDTO()
                {
                    Token = "User not found!",
                    User = null
                });
            }

            if(!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return BadRequest(new UserAndTokenDTO()
                {
                    Token = "Wrong Password!",
                    User = null
                }) ;
			}

            string token;

            try
            {
                token = await CreateToken(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

			return Ok(new UserAndTokenDTO()
            {
                Token = token,
                User = _utility.GetAppUserDTOFromUser(user)
            });
		}

        public async Task<List<Claim>> GetUserClaims(AppUser user)
        {
            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);
            List<Claim> userClaims = userRoles.Select(u => new Claim(ClaimTypes.Role, u)).ToList();

            userClaims.Add(new Claim(ClaimTypes.Email, user.Email));
            userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
            userClaims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            userClaims.Add(new Claim(ClaimTypes.StreetAddress, user.Address));

            return userClaims;
        }





        private async Task<string> CreateToken(AppUser user)
        {

            List<Claim> userClaims =  await GetUserClaims(user);
            

            //List<Claim> claims = new List<Claim>()
            //{

            //    new Claim(ClaimTypes.Role,GetUserRolesAsClaimList( await _userManager.GetRolesAsync(user))),
            //    new Claim(ClaimTypes.Name,"Mr Administrator")
            //};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _configuration.GetSection("AppSettings:Token").Value! ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims:userClaims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


	}

	
}
