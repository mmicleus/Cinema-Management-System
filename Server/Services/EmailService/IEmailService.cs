using BlazorCinemaMS.Shared.DTOs;

namespace BlazorCinemaMS.Server.Services.EmailService
{
    public interface IEmailService
    {
        public void SendEmail(EmailDTO request);
        
    }
}
