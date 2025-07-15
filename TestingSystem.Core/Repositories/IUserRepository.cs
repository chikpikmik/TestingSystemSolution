using TestingSystem.Core.Models;


namespace TestingSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetUserByLogin(string login);
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<bool> LoginExists(string login);
    }
}
