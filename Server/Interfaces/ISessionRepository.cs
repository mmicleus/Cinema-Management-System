using CinemaMS.Models;

namespace CinemaMS.Interfaces
{
    public interface ISessionRepository
    {
        Task<bool> Add(Session session);
        bool Update(Session session);

        bool Delete(Session session);

        bool Save();

        Task<bool> SaveAsync();

        Task<bool> AddBooking(Booking booking);

        Task<int> AddBookingWithId(Booking booking);

       // Task<IEnumerable<Session>> GetAllSessionsAsync();

        Task<List<Session>> GetAllSessionsAsync();

        Task<List<Session>> GetAllSessionsCompleteAsync();


		//Task<IEnumerable<Session>> GetSessionsByVenueAsync(int venueId);

        Task<IEnumerable<Session>> GetSessionsByBranchAsync(int branchId);

        Task<IEnumerable<Session>> GetSessionsByMovieAsync(int movieId);

        Task<IEnumerable<Session>> GetSessionsByDateAsync(DateOnly date);

        Task<Session> GetSessionByIdAsync(int id);

        Task<Session> GetCompleteSessionByIdAsync(int id);

        Task<Session> GetSessionWithBookingsByIdAsync(int sessionId);

        Task<IEnumerable<Session>> GetSessionsByBranchIdAsync(int branchId);

        Task<bool> DeleteSessionByIdAsync(int sessionId);




		Venue? GetVenueById(int venueId);

        Branch? GetBranchById(int branchId);



    }
}
