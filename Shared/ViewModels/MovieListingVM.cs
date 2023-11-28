using BlazorCinemaMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
    public class MovieListingVM
    {
        public MovieDTO Movie { get; set; }

        public List<SessionsWithDateVM> SessionsWithDate { get; set; }
    }
}
