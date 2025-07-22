using TestingSystem.Core.DTOs;

namespace TestingSystem.Core.Services {
    public interface IUserService
    {
        Task<UserProfileDto?> Authenticate(UserLoginDto userLoginDto);
        Task<UserProfileDto> Register(UserRegisterDto userRegisterDto);
        Task<UserProfileDto?> GetProfile(int userId);
        //Task UpdateUser(UserProfileUpdateDto user);
    }
}
