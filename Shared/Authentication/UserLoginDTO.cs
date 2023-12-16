using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.Authentication
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage ="Email required")]
        [EmailAddress(ErrorMessage= "Invalid Email")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        [RegularExpression(@"^.{9,30}$",ErrorMessage ="Password must contain between 9 and 30 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
