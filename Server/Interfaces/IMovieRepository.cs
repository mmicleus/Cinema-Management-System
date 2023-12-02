using CinemaMS.Models;

namespace CinemaMS.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<IEnumerable<Movie>> GetAllMoviesNoTrackingsAsync();

        Task<IEnumerable<Movie>> GetAllActiveMoviesAsync();


		Task<IEnumerable<Genre>> GetAllGenresAsync();

        Task<Genre> GetGenreByNameAsync(string name);

        Task<Movie> GetMovieByIdAsync(int id);

        Task<Movie> GetMovieByTitleAsync(string title);

        Task<bool> DeleteByIdAsync(int movieId);




		bool Add(Movie movie);

        bool Delete(Movie movie);


		bool Update(Movie movie);

        Task<bool> SaveAsync();


	}
}
