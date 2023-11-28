using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CinemaMS.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        public int Capacity { get; set; }

        public string Name { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        
        public Branch Branch { get; set; }

        public IEnumerable<Seat> Seats { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public IEnumerable<Session> Sessions { get; set; }

        [Required]
        public int NrOfRows { get; set; }

        [Required]
        public int NrOfColumns { get; set; }


        public override string ToString()
        {
            return "Id:" + Id + "\n"
                + "Name:" + Name + "\n"
                + "Capacity:" + Capacity + "\n"
                + "Seats:" + String.Join(',', Seats.Select(s => s.ToString()));
        }


    }
}