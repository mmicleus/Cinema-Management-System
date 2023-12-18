using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaMS.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);

            return Save();
        }

        public bool UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);

            return Save();
        }

        public bool DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);

            return Save();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.User)
                .Include(b => b.Seats)
                .ToListAsync();
        }


        public async Task<IEnumerable<Booking>> GetBookingsByUser(string userId)
        {
            return await _context.Bookings
                .Include(b => b.Seats)
                .Include(b => b.Session)
                .ThenInclude(s => s.Pricing)
                .Include(b => b.Session)
                .ThenInclude(m => m.Movie)
                .ThenInclude(m => m.Genres)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.Include(b => b.Customer).Include(b => b.User).Include(b => b.Seats).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsBySessionAsync(int sessionId)
        {
            return await _context.Bookings.Include(b => b.Customer).Include(b => b.User).Include(b => b.Seats).Where(b => b.SessionId == sessionId).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId)
        {
            return await _context.Bookings.Include(b => b.Customer).Include(b => b.User).Include(b => b.Seats).Where(b => b.UserId == userId).ToListAsync();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        


    }
}
