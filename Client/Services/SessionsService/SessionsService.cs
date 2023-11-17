﻿using BlazorCinemaMS.Client.Pages.Admin;
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


		public async Task GetSessions()
		{
			string url = "api/Admin/completeSessions";
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

			Sessions = result;
		}





	}
}

