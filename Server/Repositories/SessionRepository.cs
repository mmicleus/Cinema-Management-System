using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            return await _context.Sessions
                .Include(s => s.Pricing)
                .Include(s => s.Movie)
                .Include(s => s.Bookings).ThenInclude(b => b.User)
                .Include(s => s.Bookings).ThenInclude(b => b.Customer)
                .Include(s => s.Venue).ThenInclude(v => v.Branch)
                .ToListAsync();
        }

		





		public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _context.Sessions.Include(s => s.Pricing).Include(s => s.Movie).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> GetSessionsByBranchAsync(int branchId)
        {
            return await _context.Sessions.Include(s => s.Pricing)
                .Include(s => s.Movie)
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
            return await _context.Sessions.Where(s => s.Venue.BranchId == branchId).ToListAsync();
        }



        

        
    }
}
