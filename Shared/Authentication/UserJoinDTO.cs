using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.Authentication
{
    public class UserJoinDTO
    {
        [Required(ErrorMessage ="Username Required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage ="Username can only contain alphanumeric characters")]
        public string Username { get; set; }

 



        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Phone Number required")]
        [Phone(ErrorMessage="Invalid Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; } = string.Empty;



        [Required(ErrorMessage = "Password Required")]
        [RegularExpression(@"^.{9,30}$", ErrorMessage = "Password must contain between 9 and 30 characters")]
        public string Password { get; set; } = string.Empty;

    }
}
