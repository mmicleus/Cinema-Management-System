using BlazorCinemaMS.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class VenueDTO
	{
		public int Id { get; set; }

		public int Capacity { get; set; }

		public string Name { get; set; }

		public int BranchId { get; set; }

		public BranchDTO Branch { get; set; }

		public IEnumerable<SeatDTO> Seats { get; set; }

		public IEnumerable<SessionDTO> Sessions { get; set; }
	}
}
