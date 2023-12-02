using CinemaMS.Data;
using CinemaMS.Interfaces;
using CinemaMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CinemaMS.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context){

            _context = context;
        }

        public bool Add(Movie movie)
        {
            _context.Movies.Add(movie);

            return Save();
        }

        public bool Delete(Movie movie)
        {
            _context.Remove(movie);

            return Save();  
        }

        public async Task<bool> DeleteByIdAsync(int movieId)
        {
            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if(movie == null)
            {
                return false;
            } 

            _context.Movies.Remove(movie);

            return await SaveAsync();

        }

        public bool Update(Movie movie)
        {
            _context.Movies.Update(movie);

            return Save();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Genres).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(i => i.Title == title);
        }

        public bool Save()
        {
            int result = _context.SaveChanges();

            return result > 0 ? true : false; 
        }

        public async Task<bool> SaveAsync()
        {
			int result = await _context.SaveChangesAsync();

			return result > 0 ? true : false;
		}

        //-------------------------     Genre Repository  --------------------------


        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

       /* public async Task<IEnumerable<Movie>> GetMoviesWithSessionsByBranch(int branchId)
        {
            return await _context.Movies.Include(m => m.Sessions).Where(m => m.);
        }*/

        public async Task<IEnumerable<Movie>> GetAllMoviesNoTrackingsAsync()
        {
            return await _context.Movies.Include(m => m.Sessions).AsNoTracking().ToListAsync();
        }

		public async Task<IEnumerable<Movie>> GetAllActiveMoviesAsync()
		{
            return await _context.Movies.Where(m => m.Sessions != null && m.Sessions.Count() > 0).ToListAsync();
		}




	}
}
