using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class VenueVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name Required")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Capacity Required")]
		public int Capacity { get; set; }

        public int NrOfRows { get; set; }

        public int NrOfColumns { get; set; }



        public IEnumerable<SeatVM> Seats { get; set; } = new List<SeatVM>();	

	}
}
