using System.Text.Json.Serialization;

namespace BlazorCinemaMS.Shared.DTOs
{
    public class ApiMovieDTO
    {
        
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string title { get; set; }

        public string original_language { get; set; }
        public string overview { get; set; }

        public string poster_path { get; set; }

        public string media_type { get; set; }

        public int[] genre_ids { get; set; }


        public string release_date { get; set; }

        public double vote_average { get; set; }
    }
}
