using CinemaMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaMS.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Pricing> Pricings { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Venue> Venues { get; set; } 

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Coords> Coords { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Customer> Customers { get; set; }

        
    }
}
