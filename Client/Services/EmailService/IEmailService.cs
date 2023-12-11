using BlazorCinemaMS.Shared.DTOs;

namespace BlazorCinemaMS.Client.Services.EmailService
{
    public interface IEmailService
    {
        Task<bool> SendConfirmationEmail(SessionAndBookingDTO data);
    }
}
