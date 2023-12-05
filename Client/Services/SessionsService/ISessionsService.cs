using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;

namespace BlazorCinemaMS.Client.Services.SessionsService
{
	public interface ISessionsService
	{

		List<SessionDTO> Sessions { get; set; }

        Task<bool> AddSession(SessionVM sessionVM);

		Task GetSessions();

		SessionDTO GetLocalSessionById(int sessionId);

		Task<SessionDTO> GetSessionByIdWithSeats(int sessionId);

		Task<SessionDTO> GetFullSessionById(int sessionId);

		Task<SessionDTO> GetFullSessionByIdForUser(int sessionId);

		Task<bool> AddBooking(BookingDTO booking);




        Task<bool> DeleteSession(int sessionId);

		void DeleteLocalSession(int sessionId);




	}
}
