
using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using System.Net.Http.Json;
using System.Reflection;
using System.Xml.Linq;

namespace BlazorCinemaMS.Client.Services.MoviesService
{
    public class MoviesService : IMoviesService
    {

        public MovieDetailsDTO MovieDetails { get; set; } = 
            new MovieDetailsDTO()
        {
            genres = new List<GenreDTO>()
        };

        public TrendingMoviesDTO TrendingMovies { get; set; } = new TrendingMoviesDTO()
        {
            results = new List<ApiMovieDTO>()
        };

        public TrendingMoviesDTO MovieSuggestions { get; set; } = new TrendingMoviesDTO();

		public List<MovieDTO> Movies { get; set; } = new List<MovieDTO>();


		private readonly HttpClient _http;
        public MoviesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> AddMovie(int movieId)
        {

			string url = "api/Admin/movies";
            bool result;


            try
            {
                var response = await _http.PostAsJsonAsync(url, movieId);

                result = await response.Content.ReadAsAsync<bool>();
            }
            catch (Exception ex)
            {
                result = false;
            }


            return result;
        }

        public MovieDTO? GetLocalMovieById(int movieId) {
        
            return Movies.FirstOrDefault(m => m.Id == movieId);
		}


        public void DeleteLocalMovie(int movieId)
        {
            MovieDTO? movie = GetLocalMovieById(movieId);

            if (movie != null)
            {
                Movies.Remove(movie);
            }
        }


        public async Task<bool> DeleteMovie(int movieId)
        {
			string url = $"api/Admin/movies/{movieId}";
			bool result;


			try
			{
				result = await _http.DeleteFromJsonAsync<bool>(url);

				//result = await response.Content.ReadAsAsync<bool>();
			}
			catch (Exception ex)
			{
				result = false;
			}

            if(result == true)
            {
                DeleteLocalMovie(movieId);
            }


			return result;


		}




        public async Task GetMovieById(int id)
        {


            MovieDetailsDTO result = new MovieDetailsDTO();
            //  HttpClient _http = _httpFactory.CreateClient();
            // string url = _config.GetSection("movieDetailsURL").Value + id.ToString() + "?api_key=" + _config.GetSection("THEMOVIEDB_API_KEY").Value;


            string url = "api/Admin/movies/" + id;

            try
            {
                result = await _http.GetFromJsonAsync<MovieDetailsDTO>(url);
            }
            catch (Exception ex)
            {
                MovieDetails = null;
            }

            MovieDetails = result;

        }


        public async Task GetAllMovies()
        {
			IEnumerable<MovieDTO> result = new List<MovieDTO>();
            string url = "api/Admin/movies";

			try
			{
				result = await _http.GetFromJsonAsync<IEnumerable<MovieDTO>>(url);
			}
			catch (Exception ex)
			{
                Movies = null;
			}

            Movies = result.ToList();
		}



        public async Task GetMovieSuggestionsByName(string name)
        {

            //  return new TrendingMoviesDTO();
            /*
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_config.GetSection("movieSearchURL").Value)
            };*/



            TrendingMoviesDTO result = new TrendingMoviesDTO();
            // HttpClient _http = _httpFactory.CreateClient();
            string url = "api/Admin/movieSuggestions/" + name;

            try
            {
                result = await _http.GetFromJsonAsync<TrendingMoviesDTO>(url);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MovieSuggestions = null;

            }

            MovieSuggestions = result;

            //   return result;

        }


        public async Task GetTrendingMovies()
        {


            /*
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(@"https://localhost:7032/api/Admin")
            };
            *
            */

            // HttpClient httpClient = new HttpClient();


            TrendingMoviesDTO result = new TrendingMoviesDTO();
            // HttpClient _http = _httpFactory.CreateClient();
            string url = "api/Admin/topMovies";

            // Console.WriteLine(httpClient.BaseAddress);

            try
            {
                result = await _http.GetFromJsonAsync<TrendingMoviesDTO>(url);
                Console.WriteLine("result:" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TrendingMovies = null;
            }

            TrendingMovies = result;
        }
    }
}
