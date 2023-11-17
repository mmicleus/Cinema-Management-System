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

		public string Address { get; set; }


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
