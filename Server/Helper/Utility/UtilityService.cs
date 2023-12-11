using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;

using Mapster;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorCinemaMS.Server.Helper.Utility
{
    public class UtilityService : IUtilityService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ISessionRepository _sessionRepo;
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public UtilityService(IMovieRepository movieRepository,
            ISessionRepository sessionRepository,
            IConfiguration config)
        {
            _movieRepo = movieRepository;
            _sessionRepo = sessionRepository;
            _config = config;
        }

        public string GetFormattedMovieStartTime(DateTime time)
        {
            return time.ToString("ddd, dd MMMM");
        }

        public string GetSeatAsHTML(SeatDTO seat)
        {
            return $"<span>{seat.Label}</span>";
        }


        public string GetTicketsAsString(SessionAndBookingDTO data)
        {
            return string.Join("&nbsp;&nbsp;&nbsp;", data.Booking.Seats.Select(s => GetSeatAsHTML(s)));    
        }

        public string GetBookingAsString(SessionAndBookingDTO booking)
        {   
           return $"<div> <h2>{booking.Session.Movie.Title}</h2><span>{booking.Session.Venue.Branch.Name + " " + booking.Session.Venue.Name} </span> <br> <span> {GetFormattedMovieStartTime(booking.Session.StartTime)} </span> <div><h3><b>Seats:</b></h3> <div>{GetTicketsAsString(booking)}</div></div> <p><span><h3><b>Paid:</b></h3></span> <span>€{booking.Booking.TotalAmount}</span> </p><div>";
        }

        public string GetEmailBody(SessionAndBookingDTO data)
        {

            string intro = $"<h2>Dear {data.Booking.Customer.FirstName},<br> The following booking has been made:</h2><br>";


            var bookingAsString = GetBookingAsString(data);
            //var bookings = fo.bookings.Select((booking) => GetBookingAsString(booking));


            return intro + bookingAsString;
        }



        public EmailDTO GetEmail(SessionAndBookingDTO data)
        {
            return new EmailDTO
            {
                To = data.Booking.Customer.Email,
                Subject = "Order Confirmation",
                Body = GetEmailBody(data)
            };
        }

        public Customer GetCustomerFromCustomerDTO(CustomerDTO customerDTO)
        {
            return new Customer()
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address,
                NameOnCard = customerDTO.NameOnCard,
                CardNumber = customerDTO.CardNumber,
                ExpMonth = customerDTO.ExpMonth,
                ExpYear = customerDTO.ExpYear,
                CVV = customerDTO.CVV,
            };
        }


        public CustomerDTO GetCustomerDTOFromCustomer(Customer customer)
        {
            return new CustomerDTO()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                NameOnCard = customer.NameOnCard,
                CardNumber = customer.CardNumber,
                ExpMonth = customer.ExpMonth,
                ExpYear = customer.ExpYear,
                CVV = customer.CVV,
            };
        }



        public Booking GetBookingFromBookingDTO(BookingDTO bookingDTO)
        {
            return new Booking()
            {
                TotalAmount = bookingDTO.TotalAmount,
                Customer = GetCustomerFromCustomerDTO(bookingDTO.Customer),
                Seats = bookingDTO.Seats.Adapt<Collection<Seat>>(),
                SessionId = bookingDTO.SessionId
            };
        }





     



        public List<Session> GetSessionsByDate(List<Session> sessions, DateOnly date)
        {
            return sessions.Where(s => date.CompareTo(DateOnly.FromDateTime(s.StartTime)) == 0).ToList();
        }

        public List<Seat> ExtractAllBookedSeats(List<Booking> bookings)
        {
            List<Seat> bookedSeats = new List<Seat>();

            foreach (Booking bk in bookings)
            {
                foreach (Seat st in bk.Seats)
                {
                    bookedSeats.Add(st);
                }
            }


            return bookedSeats;
        }


        public async Task<List<Movie>> GetAllMoviesAndSessionsInBranch(int id)
        {
            IEnumerable<Movie> movies = await _movieRepo.GetAllMoviesNoTrackingsAsync();

            IEnumerable<Session> sessions = await _sessionRepo.GetSessionsByBranchAsync(id);

            foreach (Movie m in movies)
            {
                m.Sessions = m.Sessions.Where(s => sessions.Select(i => i.Id).Contains(s.Id));
            }

            return movies.Where(m => m.Sessions.Count() > 0).ToList();
        }

        public int GetRandomDurationInMinutes(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public Genre GetGenreFromGenreDTO(GenreDTO genreDTO)
        {
            Genre genre = new Genre()
            {
                Name = genreDTO.Name
            };

            return genre;
        }

        public IEnumerable<Genre> GetGenresFromGenreDTOs(IEnumerable<GenreDTO> genreDTOs)
        {
            List<Genre> genres = new List<Genre>();

            foreach (var genreDTO in genreDTOs)
            {
                genres.Add(GetGenreFromGenreDTO(genreDTO));
            }

            return genres;

        }

		public Session GetSessionFromSessionVM(SessionVM sessionVM)
        {
            return sessionVM.Adapt<Session>();
        }




        public Movie GetMovieFromMovieDetailsDTO(MovieDetailsDTO movieDTO)
        {
            Movie movie = new Movie()
            {
                Title = movieDTO.original_title,
                Overview = movieDTO.overview,
                Duration = GetRandomDurationInMinutes(60, 150),
                BackdropPath = movieDTO.backdrop_path,
                PosterPath = movieDTO.poster_path,
                ReleaseDate = DateTime.TryParse(movieDTO.release_date, out DateTime result) == true ? result : null,
                VoteAverage = movieDTO.vote_average,
                Genres = GetGenresFromGenreDTOs(movieDTO.genres),
            };

            return movie;
        }



        public void PrependBaseAddressToImagePaths(IEnumerable<ApiMovieDTO> movies)
        {
            foreach (var item in movies)
            {
                item.backdrop_path = _config.GetSection("MoviePostersBaseAddress").Value + item.backdrop_path;
                item.poster_path = _config.GetSection("MoviePostersBaseAddress").Value + item.poster_path;
                //item.backdrop_path = "https://image.tmdb.org/t/p/original" + item.backdrop_path;
                //item.poster_path = "https://image.tmdb.org/t/p/original" + item.poster_path;
            }
        }

        public void PrependBaseAddressToImagePath(MovieDetailsDTO movie)
        {

            movie.backdrop_path = _config.GetSection("MoviePostersBaseAddress").Value + movie.backdrop_path;
            movie.poster_path = _config.GetSection("MoviePostersBaseAddress").Value + movie.poster_path;
            //item.backdrop_path = "https://image.tmdb.org/t/p/original" + item.backdrop_path;
            //item.poster_path = "https://image.tmdb.org/t/p/original" + item.poster_path;
        }

        public Coords GetCoordsFromCoordsVM(CoordsVM coordsVM)
        {
            return new Coords()
            {
                Lat = coordsVM.Lat,
                Lng = coordsVM.Lng
            };
        }

        public Seat GetSeatFromSeatVM(SeatVM seat)
        {
            return new Seat()
            {
                Label = seat.Label,
            };
        }



        public Venue GetVenueFromVenueVM(VenueVM venueVM)
        {
            return new Venue()
            {
                Id = venueVM.Id,
                Capacity = venueVM.Capacity,
                Name = venueVM.Name,
                Seats = venueVM.Seats.Select(seat => GetSeatFromSeatVM(seat)).ToList()
            };
        }
    



    public Branch GetBranchFromBranchVM(BranchVM branchVM)
    {
            return new Branch()
            {
               // Id = branchVM.Id,
                Address = branchVM.Address,
                ImageUrl = branchVM.Image,
                Name = branchVM.Name,
                Coords = new Coords()
                {
                    Lat = branchVM.Coords.Lat,
                    Lng = branchVM.Coords.Lng
                },
                Venues = branchVM.Venues.Select(venue => new Venue()
                {
                    Capacity = venue.Capacity,
                    NrOfRows = venue.NrOfRows,
                    NrOfColumns = venue.NrOfColumns,
                    Name = venue.Name,
                    Seats = venue.Seats.Select(seat => new Seat()
                    {
                        Label = seat.Label,
                        SeatClass = seat.SeatClass
                    }).ToList()
                }).ToList()
            };
    }


		public Branch GetBranchFromBranchVMWithId(BranchVM branchVM)
		{
			return new Branch()
			{
				Id = branchVM.Id,
				Address = branchVM.Address,
				ImageUrl = branchVM.Image,
				Name = branchVM.Name,
				Coords = new Coords()
				{
					Lat = branchVM.Coords.Lat,
					Lng = branchVM.Coords.Lng
				},
				Venues = branchVM.Venues.Select(venue => new Venue()
				{
					Capacity = venue.Capacity,
					Name = venue.Name,
					Seats = venue.Seats.Select(seat => new Seat()
					{
						Label = seat.Label,
					}).ToList()
				}).ToList()
			};
		}



		public List<int> GetVenueIdsToDelete(IEnumerable<Venue> newVenues, IEnumerable<Venue> oldVenues)
        {
		    List<int> IdsToDelete = new List<int>();

            foreach(Venue v in oldVenues)
            {
                int id = v.Id;
                if(!newVenues.Select(newV => newV.Id).Contains(id) && id != 0)
                {
                    IdsToDelete.Add(id);
                }
            }

            return IdsToDelete;

		}


        public List<Venue> GetNewVenues(List<Venue> venues)
        {
            return venues.Where(v => v.Id == 0).ToList();
        }


       
        

    
    






}
}
        


     
