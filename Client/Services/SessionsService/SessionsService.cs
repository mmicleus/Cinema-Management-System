using BlazorCinemaMS.Client.Pages.Admin;
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorCinemaMS.Client.Services.SessionsService
{
	public class SessionsService:ISessionsService
	{
		private readonly HttpClient _httpClient;

		public List<SessionDTO> Sessions { get; set; } = new List<SessionDTO>();	
		public SessionsService(HttpClient client)
		{
			_httpClient = client;
		}


		public async Task<bool> AddSession(SessionVM sessionVM)
		{
			string url = "api/Admin/sessions";
			bool result;

			//string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				var response = await _httpClient.PostAsJsonAsync(url, sessionVM);

				result = await response.Content.ReadAsAsync<bool>();
			}
			catch (Exception ex)
			{
				return false;
			}
			return result;
		}


        //public async Task GetSessions()
        //{
        //    string url = "api/Admin/completeSessions";
        //    List<Session> result;

        //    //string branchAsString = JsonSerializer.Serialize(branch);

        //    try
        //    {
        //        result = await _httpClient.GetFromJsonAsync<List<Session>>(url);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new List<Session>();
        //    }

        //    Sessions = result;
        //}


        public async Task GetSessions()
        {
            string url = "api/Admin/completeSessions";
            string venueUrl = "api/Admin/venues/";
            string branchUrl = "api/Admin/branches/";
            List<SessionDTO> result;

            //string branchAsString = JsonSerializer.Serialize(branch);

            try
            {
                result = await _httpClient.GetFromJsonAsync<List<SessionDTO>>(url);
            }
            catch (Exception ex)
            {
                result = new List<SessionDTO>();
            }


            
            foreach(SessionDTO session in result)
            {
                session.Venue = await _httpClient.GetFromJsonAsync<VenueDTO>(venueUrl + session.VenueId);
                session.Venue.Branch = await _httpClient.GetFromJsonAsync<BranchDTO>(branchUrl + session.Venue.BranchId);
            }
            

            Sessions = result;
        }



		public async Task<bool> DeleteSession(int sessionId)
        {
			string url = $"api/Admin/sessions/{sessionId}";
			bool result;

			//string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				result = await _httpClient.DeleteFromJsonAsync<bool>(url);
			}
			catch (Exception ex)
			{
				return false;
			}
			return result;
		}

        public void DeleteLocalSession(int sessionId)
        {
            SessionDTO session = Sessions.FirstOrDefault(s => s.Id == sessionId);

            Sessions.Remove(session);

		}




    }
}

