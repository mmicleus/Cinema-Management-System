using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CinemaMS.Models
{
    public class Branch
	{
        [Key]
        public int Id { get; set; } 

        public string Address { get; set; }

        public string Name { get; set; }

        public Coords Coords { get; set; }

        public string? ImageUrl { get; set; }


        [JsonIgnore]
		[IgnoreDataMember]
		
        public IEnumerable<Venue> Venues { get; set; }

		//public IEnumerable<Venue> Venues { get; set; }

		public override string ToString()
        {
            return "Id:" + Id + "\n"
                + "Address:" + Address + "\n"
                + "Name:" + Name + "\n"
                + "Coords" + Coords + "\n"
                + String.Join('\n', Venues.Select(v => v.ToString()));

        }

		//public override void AddCustomMappings()
		//{
		//	// Mapster can map properties with different names
		//	// Here we split the price into two properties for the model behind the DTO
		//	SetCustomMappings()
		//		.Map(dest => dest.Image,
		//			 src => src.ImageUrl);

		//	//.Map(dest => dest.Currency,
		//	//	 src => src.Price.Split(' ', StringSplitOptions.None)[1]);

		//	// Mapping from model to DTO

		//	SetCustomMappingsReverse()
		//		.Map(dest => dest.ImageUrl, src => src.Image);
		//}
	}
}