using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using System.Net.Http.Json;
//using Newtonsoft.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorCinemaMS.Client.Services.BranchesService
{
	public class BranchesService:IBranchesService
	{
		private readonly HttpClient _httpClient;
		public BranchesService(HttpClient client) { 
			_httpClient = client;
		}


		public BranchDTO FullBranch { get; set; }

		public IEnumerable<BranchDTO> Branches { get; set; } = new List<BranchDTO>();

		public IEnumerable<VenueDTO> Venues { get; set; } = new List<VenueDTO>();

		public async Task<bool> AddBranch(BranchVM branch)
		{
			string url = "api/Admin/branches";
			bool result;

			string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				var response = await _httpClient.PostAsJsonAsync(url, branchAsString);

				result = await response.Content.ReadAsAsync<bool>();
			}
			catch(Exception ex)
			{
				return false;
			}
			return result;
		}


		public async Task<bool> UpdateBranch(BranchVM branch)
		{
			string url = "api/Admin/branches";
			bool result;

			string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				var response = await _httpClient.PutAsJsonAsync(url, branchAsString);

				result = await response.Content.ReadAsAsync<bool>();
			}
			catch (Exception ex)
			{
				return false;
			}
			return result;
		}


		public async Task<bool> DeleteBranch(int branchId)
		{
			string url = $"api/Admin/branches/{branchId}";
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





		public async Task GetAllBranches()
		{
			string url = "api/Admin/branchesWithSessions";
			IEnumerable<BranchDTO> result;

			//string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				result = await _httpClient.GetFromJsonAsync<IEnumerable<BranchDTO>>(url);
			
			}
			catch (Exception ex)
			{
				result = new List<BranchDTO>();
			}

			Branches = result;
		}

		
		public async Task<List<BranchDTO>> GetJustBranches()
		{
			string url = "api/Admin/justBranches";
			IEnumerable<BranchDTO> result;

			//string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				result = await _httpClient.GetFromJsonAsync<IEnumerable<BranchDTO>>(url);

			}
			catch (Exception ex)
			{
				result = new List<BranchDTO>();
			}

			return result.ToList(); 
		}



		public BranchDTO? GetBranchById(int branchId)
		{
			return Branches.FirstOrDefault(b => b.Id == branchId);
		}

		public async Task<BranchDTO> GetFullBranchById(int branchId)
		{
			string url = $"api/Admin/fullBranches/{branchId}";
			BranchDTO result;

			//string branchAsString = JsonSerializer.Serialize(branch);

			try
			{
				result = await _httpClient.GetFromJsonAsync<BranchDTO>(url);

			}
			catch (Exception ex)
			{
				result = new BranchDTO();
			}

			return result;
		}

	
	}
}
