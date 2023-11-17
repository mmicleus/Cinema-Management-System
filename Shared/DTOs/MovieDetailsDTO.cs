namespace BlazorCinemaMS.Shared.DTOs
{
    /*
    public class GenreDTO
    {
        public int Id { get; set; }

        public string name { get; set; }
    }

    */

    public class MovieDetailsDTO
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }

        public string original_language { get; set; }
        public string overview { get; set; }

        public string poster_path { get; set; }


        public IEnumerable<GenreDTO> genres { get; set; }


        public string release_date { get; set; }

        public double vote_average { get; set; }

        public long budget { get; set; }
    }
}
