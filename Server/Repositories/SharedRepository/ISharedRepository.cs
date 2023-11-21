using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCinemaMS.Server.Repositories.SharedRepository
{
	public interface ISharedRepository
	{
		Task<IEnumerable<Venue>> GetVenuesByBranch(int branchId);

		Task<IEnumerable<Seat>> GetSeatsByVenue(int venueId);


		Task<Movie> GetMovieById(int movieId);


		Task<IEnumerable<Session>> GetSessionsByVenue(int venueId);



		Task GetCompleteBranch(Branch branch);


		Task<IEnumerable<Branch>> GetAllCompleteBranches();

	}
}
