using BlazorCinemaMS.Shared.DTOs;

namespace BlazorCinemaMS.Client.Services.UserService
{
    public interface IUserService
    {
        AppUserDTO User { get; set; }

        void SetUser(AppUserDTO user);

        AppUserDTO GetUser();

        void DeleteUser();

        Task UpdateUser();
    }
        
}
