using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class AppUserDTO
	{
		public IEnumerable<BookingDTO> Bookings { get; set; }


		public string Address { get; set; }


		//public override string ToString()
		//{
		//	return "UserId: " + Id + "\n";

		//}
	}
}
