using BlazorCinemaMS.Shared.DTOs;

namespace BlazorCinemaMS.Client.Services.MoviesService
{
    public interface IMoviesService
    {

        public MovieDetailsDTO MovieDetails { get; set; }

        public TrendingMoviesDTO TrendingMovies { get; set; }

        public TrendingMoviesDTO MovieSuggestions { get; set; }

	    List<MovieDTO> Movies { get; set; }

		Task GetMovieSuggestionsByName(string name);

        Task GetTrendingMovies();

        Task GetAllMovies();

        Task<List<MovieDTO>> GetAllActiveMovies();

		// Task DeleteMovie(int id);

		Task<bool> DeleteMovie(int movieId);





		Task GetMovieById(int id);



        Task<bool> AddMovie(int movieId);


    }
}
