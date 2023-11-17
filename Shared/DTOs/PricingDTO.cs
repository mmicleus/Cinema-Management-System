using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class PricingDTO
	{

		public double Economy { get; set; }
		public double Standard { get; set; }

		public double Premium { get; set; }


	}
}
