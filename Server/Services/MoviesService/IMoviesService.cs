

using BlazorCinemaMS.Shared.DTOs;

namespace BlazorCinemaMS.Server.Services.NetworkService
{
    public interface IMoviesService
    {
        Task<TrendingMoviesDTO> GetMovieSuggestionsByName(string name);

        Task<TrendingMoviesDTO> GetTrendingMovies();

        Task<MovieDetailsDTO> GetMovieById(int id); 


    }
}
