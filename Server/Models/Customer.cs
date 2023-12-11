using BlazorCinemaMS.Server.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaMS.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        //-----------------  Credit Card Details ----------------
        
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


        //-----------------  End of Credit Card Details ----------------


        [ForeignKey("Booking")]
        public int BookingId { get; set; }


        [JsonIgnore]
        public Booking Booking { get; set; }

       


        public override string ToString()
        {
            return "\n" + "Id: " + Id + "\n"
                + "First Name:" + FirstName + "\n"
                + "LastName:" + LastName + "\n"
                + "Email:" + Email + "\n"
                + "Address:" + Address + "\n";
        }
    }
}