using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace CinemaMS.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


        public Pricing Pricing { get; set; }


        [ForeignKey("Venue")]
        public int VenueId { get; set; }


        public Venue Venue { get; set;}


        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }


        public override string ToString()
        {
            return "\n" + "Id:" + Id + "\n"
                + "StartTime:" + StartTime + "\n"
                + "EndTime:" + EndTime + "\n"
               // + "VenueId:" + VenueId + "\n"
                + "MovieTitle:" + Movie.Title + "\n"
                + "Pricing:" + Pricing + "\n";

        }
    }
}