using TestingSystem.Core.Models;
using TestingSystem.Core.Repositories;
using TestingSystem.Core.Utils;

namespace TestingSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Authenticate(string login, string password)
        {
            var user = await _userRepository.GetUserByLogin(login);
            if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null; // Аутентификация не удалась
            }
            return user;
        }

        public async Task<User> Register(string username, string login, string password)
        {
            // Валидация
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Имя пользователя, логин и пароль обязательны.");
            }

            if (await _userRepository.LoginExists(login))
            {
                throw new ArgumentException("Пользователь с таким логином уже существует.");
            }

            // Хэширование пароля
            var (hash, salt) = _passwordHasher.HashPassword(password);

            // Создание пользователя
            var user = new User
            {
                Name = username,
                Login = login,
                PasswordHash = hash,
                PasswordSalt = salt,
            };

            await _userRepository.Add(user);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }
    }
}