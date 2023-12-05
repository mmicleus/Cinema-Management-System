using BlazorCinemaMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class CustomerVM
	{
		//	public int Id { get; set; }

		[Required(ErrorMessage="First Name Required")]
		public string FirstName { get; set; }

		[Required(ErrorMessage="Last Name Required")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Last Name Required")]
		[EmailAddress(ErrorMessage="Invalid Email Format")]
		public string Email { get; set; }

		[Phone(ErrorMessage="Invalid Phone Number")]
		public string Phone { get; set; }

		public CreditCardDetailsVM CreditCardDetails { get; set; }

		[Required(ErrorMessage="Address Required")]
		public string? Address { get; set; }


		


		//public int BookingId { get; set; }
		//public BookingDTO Booking { get; set; }

	}
}
