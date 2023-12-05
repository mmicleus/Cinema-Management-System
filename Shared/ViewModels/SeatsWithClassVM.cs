using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
    public class SeatsWithClassVM
    {
        public SeatClass SeatClass { get; set; }



        public IEnumerable<SeatDTO> Seats { get; set; }
    }
}
