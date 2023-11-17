using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class BookingDTO
	{
		public int Id { get; set; }

		public double TotalAmount { get; set; }


		public CustomerDTO? Customer { get; set; }

		public string? UserId { get; set; }

		public AppUserDTO? User { get; set; }


		public int SessionId { get; set; }

		public SessionDTO Session { get; set; }


		//public IEnumerable<Seat> Seats { get; set; }


		//public override string ToString()
		//{
		//	return "\n" +
		//		"Id: " + Id + "\n"
		//		+ "Customer:" + Customer + "\n"
		//		+ "User" + User + "\n"
		//		+ "Amount:" + TotalAmount + "\n"
		//		+ "SessionId:" + SessionId + "\n"
		//		+ "Seats:" + String.Join(',', Seats.Select(s => s.ToString())) + "\n";
		//}
	}
}
