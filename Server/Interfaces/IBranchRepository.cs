using CinemaMS.Models;

namespace CinemaMS.Interfaces
{
    public interface IBranchRepository
    {
        Task<bool> AddBranch(Branch branch);

        Task<bool> DeleteBranch(Branch branch);

        Task<bool> UpdateBranch(Branch branch);

        Task<Branch> GetBranchByIdAsync(int id);

        Task<Branch> GetBranchByNameAsync(string name);

        Task<IEnumerable<Branch>> GetAllBranchesAsync();

        Task<IEnumerable<Branch>> GetAllBranchesWithSessionsAsync();

        Task<IEnumerable<Branch>> GetAllBranchesWithoutVenuesAsync();

        Task<Branch> GetFullBranchDataByIdExplicitLoading(int branchId);

        Task<Branch> GetFullBranchById(int branchId);


		Task<IEnumerable<Seat>> GetSeatsByVenueIdAsync(int venueId);

        Task<bool> DeleteBranchById(int branchId);


		Task<Venue> GetVenueByIdWithSeatsAsync(int venueId);

        Task<Venue> GetVenueByIdWithBranch(int venueId);

        Task<bool> SaveAsync();
    }
}
