using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.Enums;
using System.Security.Claims;

namespace BlazorCinemaMS.Client.Services.UtilityService
{
	public interface IUtilityService
	{

		double GetSeatPriceByClass(SeatClass seatClass, PricingDTO pricing);
		bool IsSameDay(DateTime date1, DateTime date2);

		string FormatMinutes(int minutes);

		bool IsOfRole(string role, IEnumerable<Claim> claims);
	}
}
