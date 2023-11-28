namespace BlazorCinemaMS.Client.Services.UtilityService
{
	public class UtilityService:IUtilityService
	{

		public bool IsSameDay(DateTime date1, DateTime date2)
		{
			if (date1.Year.Equals(date2.Year) && date1.Month.Equals(date2.Month) && date1.Day.Equals(date2.Day)) return true;

			return false;
		}
		
	}
}
