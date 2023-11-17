using CinemaMS.Data;
using CinemaMS.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace CinemaMS.Helper
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;

       
        private static List<Seat> SeatsV1 = new List<Seat>()
            {
                new Seat()
        {
            Label = "A1",
                },
                new Seat()
        {
            Label = "A2",
                },
                new Seat()
        {
            Label = "A3",
                },
                new Seat()
        {
            Label = "B1",
                },
                new Seat()
        {
            Label = "B2",
                },
                new Seat()
        {
            Label = "B3",
                },
                new Seat()
        {
            Label = "C1",
                },
                new Seat()
        {
            Label = "C2",
                },
                new Seat()
        {
            Label = "C3",
                }
    };

        private static List<Seat> SeatsV2 = new List<Seat>()
            {
                new Seat()
        {
            Label = "A1",
                },
                new Seat()
        {
            Label = "A2",
                },
                new Seat()
        {
            Label = "A3",
                },
                new Seat()
        {
            Label = "B1",
                },
                new Seat()
        {
            Label = "B2",
                },
                new Seat()
        {
            Label = "B3",
                },
                new Seat()
        {
            Label = "C1",
                },
                new Seat()
        {
            Label = "C2",
                },
                new Seat()
        {
            Label = "C3",
                }
    };

        private static List<Seat> SeatsV3 = new List<Seat>()
            {
                new Seat()
        {
            Label = "A1",
                },
                new Seat()
        {
            Label = "A2",
                },
                new Seat()
        {
            Label = "A3",
                },
                new Seat()
        {
            Label = "B1",
                },
                new Seat()
        {
            Label = "B2",
                },
                new Seat()
        {
            Label = "B3",
                },
                new Seat()
        {
            Label = "C1",
                },
                new Seat()
        {
            Label = "C2",
                },
                new Seat()
        {
            Label = "C3",
                }
    };

        private static List<Seat> SeatsV4 = new List<Seat>()
            {
                new Seat()
        {
            Label = "A1",
                },
                new Seat()
        {
            Label = "A2",
                },
                new Seat()
        {
            Label = "A3",
                },
                new Seat()
        {
            Label = "B1",
                },
                new Seat()
        {
            Label = "B2",
                },
                new Seat()
        {
            Label = "B3",
                },
                new Seat()
        {
            Label = "C1",
                },
                new Seat()
        {
            Label = "C2",
                },
                new Seat()
        {
            Label = "C3",
                }
    };

        private static List<Venue> Venues1 = new List<Venue>()
            {
                new Venue()
        {
            Capacity = 9,
                    Name = "Screen 1",
                    Seats = SeatsV1
                },
                new Venue()
        {
            Capacity = 9,
                    Name = "Screen 2",
                    Seats = SeatsV2
                },
            };

        private static List<Venue> Venues2 = new List<Venue>()
            {
                new Venue()
        {
            Capacity = 9,
                    Name = "Screen 1",
                    Seats = SeatsV3
                },
                new Venue()
        {
            Capacity = 9,
                    Name = "Screen 2",
                    Seats = SeatsV4
                },
            };


        private static List<Booking> BookingsB1 = new List<Booking>()
            {
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "John",
                        LastName = "Wick",
                        Email = "User@gmail.com",
                        Address = "Calea Iesilor"
                    },
                    TotalAmount = 14,
                    Seats = SeatsV1
                },
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "Teddy",
                        LastName = "Smith",
                        Email = "User2@gmail.com",
                        Address = "Willow Green"
                    },
                    TotalAmount = 14,
                    Seats = SeatsV2
                }
            };

        private static List<Booking> BookingsB2 = new List<Booking>()
            {
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "John",
                        LastName = "Wick",
                        Email = "User@gmail.com",
                        Address = "Calea Iesilor"
                    },
                    TotalAmount = 14,
                    Seats = SeatsV3
                },
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "Teddy",
                        LastName = "Smith",
                        Email = "User2@gmail.com",
                        Address = "Willow Green"
                    },
                    TotalAmount = 14,
                    Seats = SeatsV4
                }
            };

        private static List<Movie> Movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Title = "Titanic",
                        Overview = "Movie about a sinking ship",
                        Duration = 120,
                        MovieDbId = 1,
                        BackdropPath = "https://media.cnn.com/api/v1/images/stellar/prod/230213144330-02-titanic-25th-anniversary-restricted.jpg?c=original",
                        PosterPath = "https://media.cnn.com/api/v1/images/stellar/prod/230213144330-02-titanic-25th-anniversary-restricted.jpg?c=original",
                        ReleaseDate = DateTime.Now,
                        VoteAverage = 9.7,
                        Genres = GetGenres()
                    },
                    new Movie()
                    {
                        Title = "Rambo",
                        Overview = "Movie about a former soldier causing havoc in a small american town",
                        Duration = 100,
                        MovieDbId = 2,
                        BackdropPath = "https://i.insider.com/568d296ac08a801b008b7416?width=911&format=jpeg",
                        PosterPath = "https://i.insider.com/568d296ac08a801b008b7416?width=911&format=jpeg",
                        ReleaseDate = new DateTime(2000,1,1),
                        VoteAverage = 9.1,
                        Genres = GetGenres()
                    },
                };


        private static List<Session> Sessions = new List<Session>()
            {
                new Session()
                {
                    StartTime = new DateTime(2023,7,12,7,0,0),
                    EndTime = new DateTime(2023,7,12,8,0,0),
                    Venue = Venues1[0],
                    Movie = Movies[0],
                    Pricing = new Pricing()
                    {
                        Economy = 4,
                        Standard = 7,
                        Premium = 10
                    },
                    Bookings = new List<Booking>()
                    {
                        BookingsB1[0]
                    }
                },
                new Session()
                {
                    StartTime = new DateTime(2023,7,12,7,0,0),
                    EndTime = new DateTime(2023,7,12,8,0,0),
                    Venue = Venues1[1],
                    Movie = Movies[1],
                    Pricing = new Pricing()
                    {
                        Economy = 4,
                        Standard = 7,
                        Premium = 10
                    },
                    Bookings = new List<Booking>()
                    {
                        BookingsB1[1]
                    }
                }
            };





     





        public DataSeeder(AppDbContext context)
        {
            this._context = context;
        }

        public static List<Genre> GetGenres()
        {
            List<Genre> Genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Thriller"
                },
                new Genre()
                {
                    Name = "Adventure"
                },

            };
            
            return Genres;
        }

        /*
        public static List<Seat> GetSeats()
        {
            var seats = new List<Seat>()
            {
                new Seat()
                {
                    Label = "A1",
                },
                new Seat()
                {
                    Label = "A2",
                },
                new Seat()
                {
                    Label = "A3",
                },
                new Seat()
                {
                    Label = "B1",
                },
                new Seat()
                {
                    Label = "B2",
                },
                new Seat()
                {
                    Label = "B3",
                },
                new Seat()
                {
                    Label = "C1",
                },
                new Seat()
                {
                    Label = "C2",
                },
                new Seat()
                {
                    Label = "C3",
                }
            };

            return seats;
        }

        */

      /*  public List<Movie> GetMovies()
        {
            

            return movies;
        }*/

        /*
        public static List<Venue> GetVenues()
        {
            var venues = new List<Venue>()
            {
                new Venue()
                {
                    Capacity = 9,
                    Name = "Screen 1",
                    Seats = SeatsV1
                },
                new Venue()
                {
                    Capacity = 9,
                    Name = "Screen 2",
                    Seats = SeatsV2
                },
            };

            return venues;
        }

        */

        public List<Branch> GetBranches()
        {
            var branches = new List<Branch>()
            {
                new Branch()
                {
                    Address = "14 The Laurels, Ashbourne",
                    Name = "Cinemax Ashbourne",
                    Coords = new Coords()
                    {
                        Lat = 12.4,
                        Lng = 30.2
                    },
                    Venues = Venues1
                },
                new Branch()
                {
                    Address = "A.Doga 32",
                    Name = "Cinemax Rascani",
                    Coords = new Coords()
                    {
                        Lat = 2.30,
                        Lng = 14.5
                    },
                    Venues = Venues2
                }
            };

            return branches;
        }


        /*
        public List<Booking> GetBookings()
        {
            List<Booking> Bookings = new List<Booking>()
            {
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "John",
                        LastName = "Wick",
                        Email = "User@gmail.com",
                        Address = "Calea Iesilor"
                    },
                    TotalAmount = 14,
                    Seats = GetSeats()
                },
                new Booking()
                {
                    Customer = new Customer()
                    {
                        FirstName = "Teddy",
                        LastName = "Smith",
                        Email = "User2@gmail.com",
                        Address = "Willow Green"
                    },
                    TotalAmount = 14,
                    Seats = GetSeats()
                }
            };

            return Bookings;
        }

        */

        /*
        public List<Session> GetSessions()
        {
            var sessions = new List<Session>()
            {
                new Session()
                {
                    StartTime = new DateTime(2023,7,12,7,0,0),
                    EndTime = new DateTime(2023,7,12,8,0,0),
                    Venue = Venues1[0],
                    Movie = Movies[0],
                    Pricing = new Pricing()
                    {
                        Economy = 4,
                        Standard = 7,
                        Premium = 10
                    },
                    Bookings = GetBookings()
                },
                new Session()
                {
                    StartTime = new DateTime(2023,7,12,7,0,0),
                    EndTime = new DateTime(2023,7,12,8,0,0),
                    Venue = Venues2[1],
                    Movie = Movies[1],
                    Pricing = new Pricing()
                    {
                        Economy = 4,
                        Standard = 7,
                        Premium = 10
                    },
                    Bookings = GetBookings()
                }
            };

            return sessions;
        }
        */

        public void Seed()
        {
            //inject data only if the "Movies" table is empty
            if (!_context.Movies.Any())
            {
                var movies = Movies;
                _context.Movies.AddRange(movies);
                _context.SaveChanges();
            }

            if (!_context.Branches.Any())
            {
                var branches = GetBranches();
                _context.Branches.AddRange(branches);
                _context.SaveChanges();
            }

            if (!_context.Sessions.Any())
            {
                var sessions = Sessions;
                _context.Sessions.AddRange(sessions);
                _context.SaveChanges();
            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = "New Jersey, USA"
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = "Dublin, Ireland"
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);

                }
            }
        }
    }
}
