using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace CinemaMS.Models
{
    public class Coords
    {
        public int Id { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        // -----------------------   Branch ---------------

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        // -------------------------------- End of Branch --------------

        public override string ToString()
        {
            return "Lat:" + Lat + "\n"
                + "Lng:" + Lng + "\n";

        }


    }
}
