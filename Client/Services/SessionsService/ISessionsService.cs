using BlazorCinemaMS.Shared.ViewModels;

namespace BlazorCinemaMS.Client.Services.SessionsService
{
	public interface ISessionsService
	{
		Task<bool> AddSession(SessionVM sessionVM);

		Task GetSessions();


	}
}
