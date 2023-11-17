using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace CinemaMS.Models
{
    public class Pricing
    {
        [Key]
        public int Id { get; set; }

        public double Economy { get; set; } 
        public double Standard { get; set; }

        public double Premium { get; set; }

        [ForeignKey("SessionId")]
        public int SessionId { get; set; }

        public Session Session { get; set; }

        public override string ToString()
        {
            return "Economy:" + Economy + "\n"
                + "Standard:" + Standard + "\n"
                + "Premium:" + Premium + "\n";
        }




    }
}