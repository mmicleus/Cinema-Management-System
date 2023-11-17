using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Address { get; set; }


        [ForeignKey("Booking")]
        public int BookingId { get; set; }  
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