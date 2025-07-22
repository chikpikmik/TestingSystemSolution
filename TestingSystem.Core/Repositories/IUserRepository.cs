using TestingSystem.Core.DTOs;


namespace TestingSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDataDto?> GetUserById(int userId);
        Task<UserDataDto?> GetUserByLogin(string login);
        Task<UserDataDto> CreateUser(UserDataDto userDataDto);
        Task<bool> LoginExists(string login);

        //Task Update(User user);
        //Task Delete(User user);
    }
}
