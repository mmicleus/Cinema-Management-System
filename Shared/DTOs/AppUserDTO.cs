using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class AppUserDTO
	{
		[JsonIgnore]
		public IEnumerable<BookingDTO> Bookings { get; set; }


        public string Username { get; set; }
        public string Phone { get; set; }

		public string Address { get; set; }

		public string Email { get; set; }

		public string NameOnCard { get; set; }

		public string CreditCardNumber { get; set; }

		public string ExpMonth { get; set; }

		public string ExpYear { get; set; }

		public string CVV { get; set; }

		//public string? UserName { get; set; }

		

		/// <summary>
		/// Gets or sets the email address for this user.
		/// </summary>
		//public string? Email { get; set; }


		//public override string ToString()
		//{
		//	return "UserId: " + Id + "\n";

		//}
	}
}
