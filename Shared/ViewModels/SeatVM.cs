using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class SeatVM
	{
		[Required(ErrorMessage ="Seat Label Required")]
		public string Label { get; set; } = string.Empty;


	}
}
