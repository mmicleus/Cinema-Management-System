using BlazorCinemaMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
   public class SessionsWithDateVM
    {
        public DateTime Date { get; set; }

        public List<SessionDTO> Sessions { get; set; }
    }
}
