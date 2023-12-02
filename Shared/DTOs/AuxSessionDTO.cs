using BlazorCinemaMS.Shared.ViewModels;
using Mapster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class AuxSessionDTO
	{
		public int Id { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }


		public PricingDTO Pricing { get; set; }


		public int MovieId { get; set; }

		public MovieDTO Movie { get; set; }

		public IEnumerable<BookingDTO> Bookings { get; set; }

		//[JsonIgnore]
		public VenueDTO Venue { get; set; }

		public int VenueId { get; set; }
	}
}
