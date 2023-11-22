using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.Others
{
	public class SearchFilters
	{
		//[Range(1,int.MaxValue,ErrorMessage="Select a movie")]
		public int MovieId { get; set; } = 0;

		//[Range(1, int.MaxValue, ErrorMessage = "Select a branch")]
		public int BranchId { get; set; } = 0;

		//[Range(1, int.MaxValue, ErrorMessage = "Select a venue")]
		public int VenueId { get; set; } = 0;

		public DateTime? FromDate { get; set; } = null;

		public string FromTime { get; set; } = String.Empty;

		public DateTime? ToDate { get; set; } = null;

		public string ToTime { get; set; } = String.Empty;
	}
}
