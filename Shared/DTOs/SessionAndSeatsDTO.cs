using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
    public class SessionAndSeatsDTO
    {
        public SessionDTO Session { get; set; }

        public IEnumerable<SeatDTO> Seats { get; set; }
    }
}
