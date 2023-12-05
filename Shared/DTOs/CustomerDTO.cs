using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class CustomerDTO
	{
	
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

        //-----------------  Credit Card Details ----------------

      //  [Required]
        public string NameOnCard { get; set; }

     //   [Required]
        public string CardNumber { get; set; }

     //   [Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string ExpMonth { get; set; }

       // [Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string ExpYear { get; set; }

      //  [Required]
        public string CVV { get; set; }


        //-----------------  End of Credit Card Details ----------------


        public int BookingId { get; set; }
		public BookingDTO Booking { get; set; }


		public override string ToString()
		{
			return "\n" + "Id: " + Id + "\n"
				+ "First Name:" + FirstName + "\n"
				+ "LastName:" + LastName + "\n"
				+ "Email:" + Email + "\n"
				+ "Address:" + Address + "\n";
		}
	}
}
