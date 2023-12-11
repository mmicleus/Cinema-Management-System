using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
    public class SessionAndBookingDTO
    {
       public BookingDTO Booking {  get; set; }

       public SessionDTO Session { get; set; }
    }
}
