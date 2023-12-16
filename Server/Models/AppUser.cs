using BlazorCinemaMS.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace CinemaMS.Models
{
    public class AppUser:IdentityUser
    {
        /*
        [Key]
        public int Id { get; set; }
        */

       // [JsonIgnore]
        public IEnumerable<Booking> Bookings { get; set; }



        


        public string Address { get; set; }


        //-----------------  Credit Card Details ----------------

        //[Required]
        public string? NameOnCard { get; set; }

        //[Required]
        public string? CardNumber { get; set; }

        //[Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string? ExpMonth { get; set; }

        //[Required]
        //[CreditCard(ErrorMessage = "Invalid Card Number")]
        public string? ExpYear { get; set; }

        //[Required]
        public string? CVV { get; set; }


        //-----------------  End of Credit Card Details ----------------




        public override string ToString()
        {
            return "UserId: " + Id + "\n";
                
        }
    }
}