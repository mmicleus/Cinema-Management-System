﻿using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.ViewModels;
using CinemaMS.Models;

namespace BlazorCinemaMS.Server.Helper.Utility
{
	public interface IUtilityService
	{
		string GetFormattedMovieStartTime(DateTime time);

		string GetSeatAsHTML(SeatDTO seat);

		public string GetTicketsAsString(SessionAndBookingDTO data);
        string GetBookingAsString(SessionAndBookingDTO booking);

        EmailDTO GetEmail(SessionAndBookingDTO data);

        Booking GetBookingFromBookingDTO(BookingDTO bookingDTO);

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
