using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;

namespace BlazorCinemaMS.Client.Services.BranchesService
{
	public interface IBranchesService
	{
		BranchDTO FullBranch { get; set; }
		IEnumerable<BranchDTO> Branches { get; set; }
		Task<bool> AddBranch(BranchVM branch);

		Task<bool> DeleteBranch(int branchId);

		IEnumerable<VenueDTO> Venues { get; set; }

		Task GetAllBranches();

		Task<List<BranchDTO>> GetJustBranches();

		//Task<BranchDTO> GetBranchByIdExplicitLoading(int branchId);

		Task<BranchDTO> GetFullBranchById(int branchId);

		BranchDTO? GetBranchById(int branchId);

		Task<bool> UpdateBranch(BranchVM branch);

		//Task<bool> DeleteSession(int sessionId);
	}
}
