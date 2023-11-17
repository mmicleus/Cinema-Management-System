﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CinemaMS.Models
{
    public class AppUser:IdentityUser
    {
        /*
        [Key]
        public int Id { get; set; }
        */

        public IEnumerable<Booking> Bookings { get; set; }


        public string Address { get; set; }


        public override string ToString()
        {
            return "UserId: " + Id + "\n";
                
        }
    }
}