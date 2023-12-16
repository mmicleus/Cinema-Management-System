using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class UserVM
	{
		[Required(ErrorMessage = "Username Required")]
		public string Username { get; set; }


		[Required(ErrorMessage="Email Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email { get; set; }

		[Phone(ErrorMessage = "Invalid Phone Number")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Address Required")]
		public string? Address { get; set; }

		[Required]
		public CreditCardDetailsVM CreditCardDetails { get; set; }

		

	}
}
