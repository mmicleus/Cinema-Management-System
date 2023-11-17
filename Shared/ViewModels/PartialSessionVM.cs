using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class PartialSessionVM
	{
		[Required(ErrorMessage = "Start Date  Required")]
		public DateTime StartDate { get; set; } = new DateTime();

		

		public PricingVM Pricing { get; set; } = new PricingVM();

		[Required(ErrorMessage = "BranchId Required")]
		public int BranchId { get; set; } = 0;

		[Required(ErrorMessage = "VenueId Required")]
		public int VenueId { get; set; } = 0;

		[Required(ErrorMessage = "Start Time Required")]
		public string StartTime { get; set; } = String.Empty;

		//[Required(ErrorMessage = "End Time Required")]
		//public string EndTime { get; set; } = String.Empty;


	}
}
