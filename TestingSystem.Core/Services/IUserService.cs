using TestingSystem.Core.Models;

namespace TestingSystem.Core.Services {
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(string username, string login, string password);
        Task<User> GetUserById(int id);
        Task UpdateUser(User user);
    }
}
