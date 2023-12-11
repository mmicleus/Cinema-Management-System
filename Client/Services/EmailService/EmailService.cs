using BlazorCinemaMS.Shared.DTOs;
using System.Net.Http;
using System.Text.Json;

namespace BlazorCinemaMS.Client.Services.EmailService
{
    public class EmailService:IEmailService
    {
        public readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendConfirmationEmail(SessionAndBookingDTO data)
        {
            string url = "api/Admin/confirmationEmail";
            bool success;
            string serialized;

            //string branchAsString = JsonSerializer.Serialize(branch);
            serialized = JsonSerializer.Serialize(data);

            try
            {
                var response = await _httpClient.PostAsJsonAsync<string>(url, serialized);
                success = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }


    }
}
