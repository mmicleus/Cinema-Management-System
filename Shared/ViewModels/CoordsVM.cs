using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class CoordsVM
	{
		[Required(ErrorMessage = "Latitude Required"),Range(-90,90,ErrorMessage ="Latitudes range from -90 to 90")]
		public double Lat { get; set; }

		[Required(ErrorMessage = "Longitude Required"), Range(-180, 180, ErrorMessage = "Longitudes range from -180 to 180")]
		public double Lng { get; set; }
	}
}
