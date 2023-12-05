using System.ComponentModel.DataAnnotations;

namespace BlazorCinemaMS.Server.Models
{
    public class CardDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameOnCard { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string ExpMonth { get; set; }

        [Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string ExpYear { get; set; }

        [Required]
        public string CVV { get; set; }




    }
}
