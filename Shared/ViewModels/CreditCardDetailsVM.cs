using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
	public class CreditCardDetailsVM
	{
		[Required(ErrorMessage = "Name on card Required")]
		public string? NameOnCard { get; set; }

		[Required(ErrorMessage = "Credit Card Number Required")]
	//	[CreditCard(ErrorMessage="Invalid Card Number")]
		[RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$", ErrorMessage = "Invalid Card Number")]
		public string? CardNumber { get; set; }

		[Required(ErrorMessage = "Expiry Month Required")]
		[RegularExpression(@"(^0[0-9]$)|(^1[0-2]$)",ErrorMessage="Invalid Month")]
		//[CreditCard(ErrorMessage = "Invalid Card Number")]
		public string? ExpMonth { get; set; }

		[Required(ErrorMessage = "Expiry Year Required")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Invalid Year")]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string? ExpYear { get; set; }

		[Required(ErrorMessage = "CVV Required")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVV")]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string? CVV { get; set; }
	}
}
