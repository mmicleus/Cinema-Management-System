using System.ComponentModel.DataAnnotations;

namespace CinemaMS.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}