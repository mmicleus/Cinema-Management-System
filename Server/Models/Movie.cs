using System.ComponentModel.DataAnnotations;

namespace CinemaMS.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Overview { get; set; }

        //The duration in minutes

        [Required]
        public int Duration { get; set; }

        [Required]
        public int MovieDbId { get; set; }

        public string BackdropPath { get; set; }

        public string PosterPath { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double VoteAverage { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Session> Sessions { get; set; }


        public override string ToString()
        {
            return "Title:" + this.Title + "\n" +
                    "Rating:" + this.VoteAverage + "\n" +
                    "Genres:" + String.Join(',', this.Genres.Select(g => g.Name)) + "\n";
        }




    }
}
