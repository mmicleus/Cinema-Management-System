using BlazorCinemaMS.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.ViewModels
{
    public class BranchVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; } = String.Empty;

        public string? Image { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; } = String.Empty;

        public CoordsVM Coords { get; set; } = new CoordsVM();


        public IEnumerable<VenueVM> Venues { get; set; } = new List<VenueVM>();

		//public override void AddCustomMappings()
		//{
		//	// Mapster can map properties with different names
		//	// Here we split the price into two properties for the model behind the DTO
		//	SetCustomMappings()
		//		.Map(dest => dest.ImageUrl,
		//			 src => src.Image);

		//	//.Map(dest => dest.Currency,
		//	//	 src => src.Price.Split(' ', StringSplitOptions.None)[1]);

		//	// Mapping from model to DTO

		//	SetCustomMappingsReverse()
		//		.Map(dest => dest.Image, src => src.ImageUrl);
		//}
	}
}
