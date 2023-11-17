using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaMS.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        
       
        public IEnumerable<Booking> Bookings { get; set; }

        public override string ToString()
        {
            return "Label:" + Label + "\n";
        }


    }
}