using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
        public class EmailDTO
        {
            public string To { get; set; } = String.Empty;
            public string Subject { get; set; } = String.Empty;

            public string Body { get; set; } = String.Empty;
        }
    
}
