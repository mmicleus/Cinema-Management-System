using BlazorCinemaMS.Server.Helper.Utility;
using BlazorCinemaMS.Server.Services.NetworkService;
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorCinemaMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
		private readonly IMovieRepository _movieRepo;
		private readonly IUtilityService _utility;
        private readonly IBranchRepository _branchRepo;
        private readonly ISessionRepository _sessionRepo;
		public AdminController(IMoviesService moviesService,
            IUtilityService utilityService,
            IMovieRepository movieRepository,
            IBranchRepository branchRepository,
            ISessionRepository sessionRepository) {
            
           _moviesService = moviesService;
            _utility = utilityService; 
            _movieRepo = movieRepository;
            _branchRepo = branchRepository;
            _sessionRepo = sessionRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/<AdminController>
        [HttpGet("topMovies")]
        public async Task<TrendingMoviesDTO> GetTrendingMovies()
        {
            return await _moviesService.GetTrendingMovies();
		}

        [HttpGet("movieSuggestions/{name}")]
        public async Task<TrendingMoviesDTO> GetMovieSuggestions(string name)
        {
            return await _moviesService.GetMovieSuggestionsByName(name);
        }

        [HttpGet("movies/{id}")]
        public async Task<MovieDetailsDTO> GetMovieById(int id)
        {
            return await _moviesService.GetMovieById(id);
        }


        [HttpDelete("movies/{id}")]
        public async Task<bool> DeleteMovieById(int id)
        {
            return await _movieRepo.DeleteByIdAsync(id);
        }



		[HttpPost("movies")]
		public async Task<bool> AddMovie([FromBody]int id)
		{
           MovieDetailsDTO movieDetails =  await GetMovieById(id);

           Movie movie = _utility.GetMovieFromMovieDetailsDTO(movieDetails);

           return _movieRepo.Add(movie);
		}




		[HttpGet("movies")]
		public async Task<IEnumerable<MovieDTO>> GetAllMovies()
		{
           IEnumerable<Movie> movies =  await _movieRepo.GetAllMoviesAsync();

           IEnumerable<MovieDTO> movieDTOs = movies.Adapt<IEnumerable<MovieDTO>>();


            return movieDTOs;
		}




		[HttpPost("branches")]
		public async Task<bool> AddBranch([FromBody] string branchAsString)
		{
            BranchVM branchVM = JsonSerializer.Deserialize<BranchVM>(branchAsString);

            Branch branch = _utility.GetBranchFromBranchVM(branchVM);

            bool result = await _branchRepo.AddBranch(branch);

            //MovieDetailsDTO movieDetails = await GetMovieById(id);

            //Movie movie = _utility.GetMovieFromMovieDetailsDTO(movieDetails);

            //return _movieRepo.Add(movie);


            return result;
		}


		[HttpPut("branches")]
		public async Task<bool> UpdateBranch([FromBody] string branchAsString)
		{
			BranchVM branchVM = JsonSerializer.Deserialize<BranchVM>(branchAsString);

         //   Branch branch = _utility.GetBranchFromBranchVMWithId(branchVM);

           Branch branch = branchVM.Adapt<Branch>();



			bool result = await _branchRepo.UpdateBranch(branch);

			//MovieDetailsDTO movieDetails = await GetMovieById(id);

			//Movie movie = _utility.GetMovieFromMovieDetailsDTO(movieDetails);

			//return _movieRepo.Add(movie);


			return result;
		}




		[HttpGet("branches")]
		public async Task<IEnumerable<BranchDTO>> GetBranches()
		{

            IEnumerable<Branch> branches =  await _branchRepo.GetAllBranchesAsync();


            IEnumerable<BranchDTO> branchDTOs = branches.Adapt<IEnumerable<BranchDTO>>();

            return branchDTOs;
		}


		[HttpDelete("branches/{id}")]
		public async Task<bool> DeleteBranches(int id)
		{
            return await _branchRepo.DeleteBranchById(id);
		}






		[HttpGet("branchesWithSessions")]
		public async Task<IEnumerable<BranchDTO>> GetBranchesWithSession()
		{

			IEnumerable<Branch> branches = await _branchRepo.GetAllBranchesWithSessionsAsync();


			IEnumerable<BranchDTO> branchDTOs = branches.Adapt<IEnumerable<BranchDTO>>();

			return branchDTOs;
		}


		[HttpPost("sessions")]
		public async Task<bool> AddSession([FromBody] SessionVM sessionVM)
		{
			//BranchVM branchVM = JsonSerializer.Deserialize<BranchVM>(branchAsString);

			Session session = _utility.GetSessionFromSessionVM(sessionVM);

			bool result = await _sessionRepo.Add(session);


			return result;
		}


		[HttpGet("sessions")]
		public async Task<List<SessionDTO>> GetAllSessions()
		{
			var result = await _sessionRepo.GetAllSessionsAsync();
			return result.Adapt<List<SessionDTO>>();
		}


		[HttpGet("completeSessions")]
		public async Task<List<SessionDTO>> GetAllSessionsComplete()
		{
            var result = await _sessionRepo.GetAllSessionsCompleteAsync();
            return result.Adapt<List<SessionDTO>>();
		}









		// GET api/<AdminController>/5
		[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
