using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BlazorCinemaMS.Server.Helper.Utility
{
	public interface IUtilityService
	{
		string GetFormattedMovieStartTime(DateTime time);

		string GetSeatAsHTML(SeatDTO seat);

		public string GetTicketsAsString(SessionAndBookingDTO data);
        string GetBookingAsString(SessionAndBookingDTO booking);

		BookingDTO GetBookingDTOFromBooking(Booking booking);


        string ExtractAuthorizationToken(string token);

		string? GetEmailFromClaims(IEnumerable<Claim> claims);


        string GetAuthorizationToken(IHeaderDictionary headers);


        SecurityToken? TestJwtSecurityTokenHandler(string token);

        EmailDTO GetEmail(SessionAndBookingDTO data);

		AppUserDTO GetAppUserDTOFromUser(AppUser user);

		bool CardDetailsAreDifferent(AppUserDTO user1, AppUser user2);

		void UpdateUser(AppUserDTO userDTO, AppUser user);

        Booking GetBookingFromBookingDTO(BookingDTO bookingDTO,AppUser user);

		Customer GetCustomerFromCustomerDTO(CustomerDTO customerDTO);

        CustomerDTO GetCustomerDTOFromCustomer(Customer customer);

        List<Session> GetSessionsByDate(List<Session> sessions, DateOnly date);

		List<Seat> ExtractAllBookedSeats(List<Booking> bookings);

		Task<List<Movie>> GetAllMoviesAndSessionsInBranch(int id);

		int GetRandomDurationInMinutes(int min, int max);

		Genre GetGenreFromGenreDTO(GenreDTO genreDTO);

		IEnumerable<Genre> GetGenresFromGenreDTOs(IEnumerable<GenreDTO> genreDTOs);

		Movie GetMovieFromMovieDetailsDTO(MovieDetailsDTO movieDTO);

		Session GetSessionFromSessionVM(SessionVM sessionVM);

		void PrependBaseAddressToImagePaths(IEnumerable<ApiMovieDTO> movies);

		void PrependBaseAddressToImagePath(MovieDetailsDTO movie);

		Branch GetBranchFromBranchVM(BranchVM branchVM);

		List<int>GetVenueIdsToDelete(IEnumerable<Venue> newVenues, IEnumerable<Venue> oldVenues);

		List<Venue> GetNewVenues(List<Venue> venues);

		Branch GetBranchFromBranchVMWithId(BranchVM branchVM);


    }
}
