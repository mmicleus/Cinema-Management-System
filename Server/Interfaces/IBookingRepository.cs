using CinemaMS.Models;

namespace CinemaMS.Interfaces
{
    public interface IBookingRepository
    {
        bool AddBooking(Booking booking);

        bool DeleteBooking(Booking booking);

        bool UpdateBooking(Booking booking);

        Task<Booking> GetBookingByIdAsync(int id);

        Task<IEnumerable<Booking>> GetBookingsBySessionAsync(int sessionId);

        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId);
        

        bool Save();
    }
}
