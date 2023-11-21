using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Mapster;
using Microsoft.Identity.Client;

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
                    Name = venue.Name,
                    Seats = venue.Seats.Select(seat => new Seat()
                    {
                        Label = seat.Label,
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
        


     
