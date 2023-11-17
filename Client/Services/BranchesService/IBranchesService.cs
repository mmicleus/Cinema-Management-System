using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;

namespace BlazorCinemaMS.Client.Services.BranchesService
{
	public interface IBranchesService
	{
		IEnumerable<BranchDTO> Branches { get; set; }
		Task<bool> AddBranch(BranchVM branch);

		Task<bool> DeleteBranch(int branchId);

		IEnumerable<VenueDTO> Venues { get; set; }

		Task GetAllBranches();

		BranchDTO? GetBranchById(int branchId);

		Task<bool> UpdateBranch(BranchVM branch);
	}
}
