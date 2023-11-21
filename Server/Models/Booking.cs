using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaMS.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public double TotalAmount { get; set; }


        public Customer? Customer { get; set; }

        [ForeignKey("AppUser")]
        public string? UserId { get; set; } 

        public AppUser? User { get; set; }


        [ForeignKey("Session")]
        public int SessionId { get; set; }

        public Session Session { get; set; }  
        

       public IEnumerable<Seat> Seats { get; set; }


        public override string ToString()
        {
            return "\n" +
                "Id: " + Id + "\n"
                + "Customer:" + Customer + "\n"
                + "User" + User + "\n"
                + "Amount:" + TotalAmount + "\n"
                + "SessionId:" + SessionId + "\n";
               // + "Seats:" + String.Join(',', Seats.Select(s => s.ToString())) + "\n";
        }

    }
}