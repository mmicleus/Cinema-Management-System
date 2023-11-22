using BlazorCinemaMS.Server.Helper.Utility;
using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemaMS.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;
		private readonly IUtilityService _utility;

		public BranchRepository(AppDbContext context,IUtilityService utility)
        {
            _context = context;
            _utility = utility;
        }


        public async Task<bool> AddBranch(Branch branch)
        {
			await _context.Branches.AddAsync(branch);
			//_context.Branches.Add(branch);

			return await SaveAsync();
        }

        public async Task<bool> DeleteBranch(Branch branch)
        {
            _context.Branches.Remove(branch);

            return await SaveAsync();
        }


		public async Task<bool> DeleteBranchById(int branchId)
		{
            Branch branch = await _context.Branches.FirstOrDefaultAsync(b => b.Id == branchId);


            return await DeleteBranch(branch);
		}



		public async Task<bool> UpdateBranch(Branch branch)
        {
           int branchId = branch.Id;

          Branch branchToUpdate = _context.Branches.Include(b => b.Venues).Include(b => b.Coords).FirstOrDefault(x => x.Id == branchId);

            
        if (branchToUpdate == null) return false;


			branchToUpdate.Name = branch.Name;
			branchToUpdate.Address = branch.Address;
			branchToUpdate.ImageUrl = branch.ImageUrl;
			branchToUpdate.Coords.Lat = branch.Coords.Lat;
            branchToUpdate.Coords.Lng = branch.Coords.Lng;


			List<int> IdsToDelete = _utility.GetVenueIdsToDelete(branch.Venues, branchToUpdate.Venues);

            List<Venue> newVenues = _utility.GetNewVenues(branch.Venues.ToList());


			foreach (int id in IdsToDelete)
			{
				Venue venueToDelete = _context.Venues.FirstOrDefault(x => x.Id == id);


                _context.Venues.Remove(venueToDelete);
			}


			

			foreach (Venue v in newVenues)
			{
				v.BranchId = branchToUpdate.Id;
                v.Seats = v.Seats.ToList();
				_context.Venues.Add(v);
			}

			return await SaveAsync();
        }



        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            IEnumerable<Branch> result = new List<Branch>();  

			try
            {       
				result = _context.Branches.Include(b => b.Coords)
				   .Include(b => b.Venues).ThenInclude(v => v.Seats).ToList();
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

		public async Task<IEnumerable<Branch>> GetAllBranchesWithSessionsAsync()
		{
			IEnumerable<Branch> result = new List<Branch>();

			try
			{
                result = _context.Branches.Include(b => b.Coords)
                   .Include(b => b.Venues).ThenInclude(v => v.Seats).ToList();
                   
                   //.Include(b => b.Venues).ThenInclude(v => v.Sessions).ThenInclude(s => s.Movie).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return result;
		}









		public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await _context.Branches.Include(b => b.Coords)
                .Include(b => b.Venues).ThenInclude(v => v.Seats).FirstOrDefaultAsync(b => b.Id == id);
        } 


        public async Task<Branch> GetBranchByNameAsync(string name)
        {
            return await _context.Branches.Include(b => b.Coords)
                 .Include(b => b.Venues).ThenInclude(v => v.Seats).FirstOrDefaultAsync(b => b.Name == name);
        }
        

        public async Task<Venue> GetVenueByIdWithSeatsAsync(int venueId)
        {
            return await _context.Venues.Include(v => v.Seats).FirstOrDefaultAsync(v => v.Id == venueId);
        }


        //         ---------------- To Delete ----------------------
        public async Task<Branch> GetFullBranchDataById(int branchId)
        {
            return await _context.Branches
                .Include(b => b.Coords)
                .Include(b => b.Venues).ThenInclude(v => v.Sessions).ThenInclude(s => s.Movie)
                .Include(b => b.Venues).ThenInclude(v => v.Seats)
                .Include(b => b.Venues).ThenInclude(v => v.Sessions).ThenInclude(s => s.Pricing)
                .FirstOrDefaultAsync(b => b.Id == branchId);

        }


        public Venue? GetVenueById(int venueId)
        {
            return _context.Venues.FirstOrDefault(v => v.Id == venueId);
        }





        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved > 0 ? true : false;
        }
    }
}
