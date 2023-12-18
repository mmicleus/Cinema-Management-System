using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.Enums;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace BlazorCinemaMS.Client.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient) {
            _httpClient = httpClient;
		}


        public AppUserDTO User { get; set; }

        

		


		public void SetUser(AppUserDTO user)
        {
            this.User = user;    
        }

        public async Task UpdateUser() {
            string url = "api/Auth/user/";

            if (this.User == null) return;

            try
            {
                this.User = await _httpClient.GetFromJsonAsync<AppUserDTO>(url + this.User.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        



        public AppUserDTO GetUser()
        {
            return this.User;
        }

        public void DeleteUser()
        {
            this.User = null;
        }
    }
}
