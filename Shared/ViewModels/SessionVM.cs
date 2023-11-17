using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class SessionVM
	{
		public DateTime StartTime { get; set; } = new DateTime();

		public DateTime EndTime { get; set; } = new DateTime();

		public PricingVM Pricing { get; set; } = new PricingVM();

		public int VenueId { get; set; }

		public int MovieId { get; set; }

	
	}
}
