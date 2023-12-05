using BlazorCinemaMS.Server.Helper.Utility;
using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaMS.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Session session)
        {
            await _context.Sessions.AddAsync(session);

            return  await SaveAsync();
        }

        public bool Delete(Session session)
        {
            _context.Sessions.Remove(session);

            return Save();
        }

		public async Task<bool> DeleteAsync(Session session)
		{
			_context.Sessions.Remove(session);

			return await SaveAsync();
		}

		public bool Update(Session session)
        {
            _context.Sessions.Update(session);

            return Save();
        }

        public bool Save()
        {
            int save = _context.SaveChanges();

            return save > 0 ? true : false;
        }

		public async Task<bool> SaveAsync()
		{
			int save = await _context.SaveChangesAsync();

			return save > 0 ? true : false;
		}


		public async Task<List<Session>> GetAllSessionsAsync()
		{
			return await _context.Sessions
				.Include(s => s.Pricing)
				.Include(s => s.Movie)
				.ToListAsync();
		}



		public async Task<List<Session>> GetAllSessionsCompleteAsync()
        {
            List<Session> sessions = await _context.Sessions
                .Include(s => s.Pricing)
                .Include(s => s.Movie)
                .Include(s => s.Bookings).ThenInclude(b => b.User)
                .Include(s => s.Bookings).ThenInclude(b => b.Customer)
				.Include(s => s.Bookings).ThenInclude(b => b.Seats)
				// .Include(s => s.Venue).ThenInclude(v => v.Branch)
				.ToListAsync();

            //foreach(Session session in sessions)
            //{
            //    session.Venue = GetVenueById(session.VenueId);
            //    session.Venue.Branch = GetBranchById(session.Venue.BranchId);
            //}

            return sessions;
        }

		

		public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _context.Sessions.Include(s => s.Pricing).Include(s => s.Movie).FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<Session> GetCompleteSessionByIdAsync(int id)
        {
            Session session = new Session();
            try
            {
                session = await GetSessionByIdAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            _context.Entry(session).Collection(s => s.Bookings).Load();


            if(session.Bookings != null)
            {
                foreach (Booking b in session.Bookings)
                {
                    _context.Entry(b).Reference(b => b.User).Load();
                    _context.Entry(b).Reference(b => b.Customer).Load();
                    _context.Entry(b).Collection(b => b.Seats).Load();
                }
            }


            //_context.Entry(session).Reference(s => s.Venue).Load();

            //_context.Entry(session.Venue).Reference(v => v.Branch).Load();

            //_context.Entry(session.Venue).Collection(s => s.Seats).Load();





            return session;
        }


        public async Task<bool> AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);

            return await SaveAsync();
        }

        public async Task<int> AddBookingWithId(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await SaveAsync();

            return booking.Id;
        }




        public async Task<bool> DeleteSessionByIdAsync(int sessionId)
		{
			Session session = await GetSessionByIdAsync(sessionId);


			return await DeleteAsync(session);
		}



		public Venue? GetVenueById(int venueId)
        {
            return _context.Venues.FirstOrDefault(v => v.Id == venueId);
        }

        public Branch? GetBranchById(int branchId)
        {
            return _context.Branches.FirstOrDefault(branch => branch.Id == branchId);   
        }


        public async Task<IEnumerable<Session>> GetSessionsByBranchAsync(int branchId)
        {
            return await _context.Sessions
                .Include(s => s.Pricing)
                .Include(s => s.Movie)
                //.Where(s => GetVenueById(s.VenueId).BranchId == branchId).ToListAsync();
                .Where(s => s.Venue.BranchId == branchId).ToListAsync();
        }

        //public async Task<IEnumerable<Session>> GetSessionsByVenueAsync(int venueId)
        //{
        //    return await _context.Sessions
        //        .Include(s => s.Pricing)
        //        .Include(s => s.Movie)
        //        .Where(s => s.VenueId == venueId).ToListAsync();
        //}

        public async Task<IEnumerable<Session>> GetSessionsByDateAsync(DateOnly date)
        {

            var result = await _context.Sessions
                .Include(s => s.Pricing)
                    .Include(s => s.Movie).ToListAsync();

          return result.Where(s => (date.CompareTo(DateOnly.FromDateTime(s.StartTime)) == 0)).ToList();        
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieAsync(int movieId)
        {
            return await _context.Sessions.Include(s => s.Pricing)
            .Include(s => s.Movie)
                   .Where(s => s.MovieId == movieId).ToListAsync();
        }


        public async Task<Session> GetSessionWithBookingsByIdAsync(int sessionId)
        {
            return await _context.Sessions
                .Include(s => s.Bookings)
                .FirstOrDefaultAsync(s => s.Id == sessionId);
        }

        public async Task<IEnumerable<Session>> GetSessionsByBranchIdAsync(int branchId)
        {
            return await _context.Sessions
                //.Where(s => GetVenueById(s.VenueId).BranchId == branchId).ToListAsync();
                .Where(s => s.Venue.BranchId == branchId).ToListAsync();
        }

    }
}
