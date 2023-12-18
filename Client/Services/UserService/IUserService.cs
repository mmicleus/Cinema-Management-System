using BlazorCinemaMS.Shared.DTOs;
using BlazorCinemaMS.Shared.Enums;

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
