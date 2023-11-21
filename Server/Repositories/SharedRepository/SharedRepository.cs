using CinemaMS.Data;
using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorCinemaMS.Server.Repositories.SharedRepository
{
	public class SharedRepository:ISharedRepository
	{
		public readonly AppDbContext _context;

		public SharedRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Venue>> GetVenuesByBranch(int branchId)
		{
			return await _context.Venues.Where(v => v.BranchId == branchId).ToListAsync();
		}

		public async Task<IEnumerable<Seat>> GetSeatsByVenue(int venueId)
		{
			return await _context.Seats.Where(s => s.VenueId == venueId).ToListAsync();
		}

		public async Task<Movie> GetMovieById(int movieId)
		{
			return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
		}

		public async Task<IEnumerable<Session>> GetSessionsByVenue(int venueId)
		{
			return await _context.Sessions.Where(s => s.VenueId == venueId).ToListAsync();
		}


		public async Task GetCompleteBranch(Branch branch)
		{
			branch.Venues = await GetVenuesByBranch(branch.Id);
			
			foreach(Venue v in branch.Venues)
			{
				v.Sessions = await GetSessionsByVenue(v.Id);

				foreach(Session session in v.Sessions)
				{
					session.Movie = await GetMovieById(session.MovieId);	
				}

				v.Seats = await GetSeatsByVenue(v.Id);
				
			}

			//return branch;
		}


		public async Task<IEnumerable<Branch>> GetAllCompleteBranches()
		{
			IEnumerable<Branch> branches = await _context.Branches.Include(b => b.Coords).ToListAsync();

			foreach(Branch b in branches)
			{
				GetCompleteBranch(b);	
			}

			return branches;
		}

	

	}
}
