using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class PricingVM
	{
		[Required(ErrorMessage = "Economy Price Required"),Range(1,double.MaxValue, ErrorMessage = "Price must be at least 1$")]
		public double Economy { get; set; }

		[Required(ErrorMessage = "Standard Price Required"), Range(1, double.MaxValue, ErrorMessage = "Price must be at least 1$")]
		public double Standard {  get; set; }

		[Required(ErrorMessage = "Premium Price Required"), Range(1, double.MaxValue,ErrorMessage ="Price must be at least 1$")]
		public double Premium { get; set; }
	}
}
