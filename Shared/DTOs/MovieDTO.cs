using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class MovieDTO
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Overview { get; set; }

		//The duration in minutes

		public int Duration { get; set; }

		public int MovieDbId { get; set; }

		public string BackdropPath { get; set; }

		public string PosterPath { get; set; }

		public DateTime? ReleaseDate { get; set; }

		public double VoteAverage { get; set; }

	    public IEnumerable<GenreDTO> Genres { get; set; }

	//	public IEnumerable<Session> Sessions { get; set; }
	}
}
