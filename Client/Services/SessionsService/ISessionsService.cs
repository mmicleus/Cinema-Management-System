using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;

namespace BlazorCinemaMS.Client.Services.SessionsService
{
	public interface ISessionsService
	{

		List<SessionDTO> Sessions { get; set; }

        Task<bool> AddSession(SessionVM sessionVM);

		Task GetSessions();

		Task<bool> DeleteSession(int sessionId);


	}
}
