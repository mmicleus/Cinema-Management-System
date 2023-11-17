namespace BlazorCinemaMS.Shared.DTOs
{
    public class TrendingMoviesDTO
    {
        public int page { get; set; }

        public IEnumerable<ApiMovieDTO> results { get; set; }

    }
}
