using BlazorCinemaMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.Authentication
{
    public class UserAndTokenDTO
    {
        public string Token { get; set; }

        public AppUserDTO User { get; set; }
    }
}
