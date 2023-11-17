
using BlazorCinemaMS.Server.Helper.Utility;
using BlazorCinemaMS.Shared.DTOs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorCinemaMS.Server.Services.NetworkService
{
    public class MoviesService : IMoviesService
    {
       // private readonly IHttpClientFactory _httpFactory;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly IUtilityService _utility;

        public MoviesService(
            //IHttpClientFactory httpFactory,
            IConfiguration config,
            HttpClient http,
            IUtilityService utility
            )
        {
           // _httpFactory = httpFactory;
            _config = config;   
            _httpClient = http;
            _utility = utility;
        }

        public async Task<MovieDetailsDTO> GetMovieById(int id)
        {
            /*
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_config.GetSection("movieDetailsURL").Value)
            };
            */


            MovieDetailsDTO result = new MovieDetailsDTO();
            //  HttpClient _http = _httpFactory.CreateClient();
            // string url = _config.GetSection("movieDetailsURL").Value + id.ToString() + "?api_key=" + _config.GetSection("THEMOVIEDB_API_KEY").Value;


            string url = "movie/" + id + "?api_key=" + _config.GetSection("THEMOVIEDB_API_KEY").Value;

            try
            {
                result = await _httpClient.GetFromJsonAsync<MovieDetailsDTO>(url);

            }
            catch (Exception ex)
            {
                return null;
            }

            _utility.PrependBaseAddressToImagePath(result);

            return result;
        }



        public async Task<TrendingMoviesDTO> GetMovieSuggestionsByName(string name)
        {

            TrendingMoviesDTO result;
           // HttpClient _http = _httpFactory.CreateClient();
            string url = "search/movie" + "?query=" +  name + "&api_key=" + _config.GetSection("THEMOVIEDB_API_KEY").Value;

            try
            {
                result = await _httpClient.GetFromJsonAsync<TrendingMoviesDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



            _utility.PrependBaseAddressToImagePaths(result.results);
            
			//foreach (var item in result.results)
			//{
			//	item.backdrop_path = _config.GetSection("MoviePostersBaseAddress").Value + item.backdrop_path;
			//	item.poster_path = _config.GetSection("MoviePostersBaseAddress").Value + item.poster_path;
			//	//item.backdrop_path = "https://image.tmdb.org/t/p/original" + item.backdrop_path;
			//	//item.poster_path = "https://image.tmdb.org/t/p/original" + item.poster_path;
			//}

			return result;

        }


        public async Task<TrendingMoviesDTO> GetTrendingMovies()
        {
            TrendingMoviesDTO result;
           // HttpClient _http = _httpFactory.CreateClient();
            string url = "trending/movie/week?api_key=" + _config.GetSection("THEMOVIEDB_API_KEY").Value;

            try
            {
                result = await _httpClient.GetFromJsonAsync<TrendingMoviesDTO>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


			_utility.PrependBaseAddressToImagePaths(result.results);

			//         foreach (var item in result.results)
			//{
			//             item.backdrop_path = "https://image.tmdb.org/t/p/original" + item.backdrop_path;
			//             item.poster_path = "https://image.tmdb.org/t/p/original" + item.poster_path;

			//}


			return result;
        }
    }
}
