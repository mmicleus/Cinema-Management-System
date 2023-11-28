using System.ComponentModel.DataAnnotations;

namespace BlazorCinemaMS.Client.Others
{
	public class VenueLayout
	{
		[Required(ErrorMessage ="Columns Required"), Range(1, 20, ErrorMessage = "Venues must have between 1 and 20 columns")]
		public int Columns {  get; set; }

		[Required(ErrorMessage ="Rows Required"),Range(5,20,ErrorMessage ="Venues must have between 5 and 20 rows")]

		public int Rows { get; set; }
	}
}
