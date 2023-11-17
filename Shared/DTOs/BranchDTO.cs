using BlazorCinemaMS.Shared.ViewModels;
using Mapster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class BranchDTO
	{
		public int Id { get; set; }

		public string Address { get; set; }

		public string Name { get; set; }

		public CoordsDTO Coords { get; set; } = new CoordsDTO();

		public string? ImageUrl { get; set; }

		public IEnumerable<VenueDTO> Venues { get; set; } = new List<VenueDTO>();
	}
}
