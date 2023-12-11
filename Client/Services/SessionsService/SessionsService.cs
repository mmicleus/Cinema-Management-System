using BlazorCinemaMS.Client.Pages.Admin;
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

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

        public async Task<CustomerDTO> GetCustomerByBookingId(int bookingId)
        {
            string url = $"api/Admin/customerByBooking/{bookingId}";
            CustomerDTO result;

            //string branchAsString = JsonSerializer.Serialize(branch);

            try
            {
                result = await _httpClient.GetFromJsonAsync<CustomerDTO>(url);
            }
            catch (Exception ex)
            {
                result = null;
            }





            return result;
        }

        public async Task GetCustomerForBookings(IEnumerable<BookingDTO> bookings)
        {
            foreach(BookingDTO booking in bookings)
            {
                    booking.Customer = await GetCustomerByBookingId(booking.Id);
                
               
            }
        }


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
                if(session.Bookings != null) await GetCustomerForBookings(session.Bookings);


            }
            

            Sessions = result;
        }



        public SessionDTO GetLocalSessionById(int sessionId)
        {
            return Sessions.FirstOrDefault(s => s.Id == sessionId);
        }


        public async Task<SessionDTO> GetFullSessionById(int sessionId)
        {
			string url = $"api/Admin/sessions/{sessionId}";
            SessionDTO result;

            //SessionDTO session = Sessions.FirstOrDefault(s => s.Id == sessionId);

            try {
				result = await _httpClient.GetFromJsonAsync<SessionDTO>(url);
			}
            catch (Exception ex)
            {
                result = null;
            }
			

            //await _httpClient.GetFromJsonAsync<IEnumerable<SeatDTO>>(url);

            return result;
		}


        public async Task<SessionDTO> GetFullSessionByIdForUser(int sessionId)
        {
            string url = $"api/Admin/completeSessions/{sessionId}";
            string venueUrl = "api/Admin/venues/";
            string branchUrl = "api/Admin/branches/";
            string seatsUrl = "api/Admin/venueSeats/";
            SessionDTO session;
            

            //SessionDTO session = Sessions.FirstOrDefault(s => s.Id == sessionId);

            try
            {
                session = await _httpClient.GetFromJsonAsync<SessionDTO>(url);
            }
            catch (Exception ex)
            {
                return null;
            }

            session.Venue = await _httpClient.GetFromJsonAsync<VenueDTO>(venueUrl + session.VenueId);
            session.Venue.Branch = await _httpClient.GetFromJsonAsync<BranchDTO>(branchUrl + session.Venue.BranchId);
            session.Venue.Seats = await _httpClient.GetFromJsonAsync<IEnumerable<SeatDTO>>(seatsUrl + session.VenueId);


            //await _httpClient.GetFromJsonAsync<IEnumerable<SeatDTO>>(url);

            return session;
        }






        public async Task<SessionDTO> GetSessionByIdWithSeats(int sessionId)
        {
            string url = "api/Admin/venueSeats/";

            SessionDTO session = Sessions.FirstOrDefault(s => s.Id == sessionId);

            session.Venue.Seats = await _httpClient.GetFromJsonAsync<IEnumerable<SeatDTO>>(url + session.VenueId);

            //await _httpClient.GetFromJsonAsync<IEnumerable<SeatDTO>>(url);

            return session;
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


        public async Task<bool> AddBooking(BookingDTO booking)
        {
            string url = $"api/Admin/bookings";
            bool result;

            //string branchAsString = JsonSerializer.Serialize(branch);

            string bookingAsString = JsonSerializer.Serialize(booking);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url,bookingAsString);

                result = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }




    }
}

