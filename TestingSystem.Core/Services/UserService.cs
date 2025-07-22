using TestingSystem.Core.DTOs;
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

        public async Task<UserProfileDto?> Authenticate(UserLoginDto userLoginDto)
        {
            if (string.IsNullOrEmpty(userLoginDto.Login) ||
                string.IsNullOrEmpty(userLoginDto.Password))
                throw new ArgumentException("Логин и пароль обязательны.");

            var user = await _userRepository.GetUserByLogin(userLoginDto.Login);
            if (user == null || !_passwordHasher.VerifyPassword(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null; // Аутентификация не удалась
            
            return new UserProfileDto 
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
            };
        }

        public async Task<UserProfileDto> Register(UserRegisterDto userRegisterDto)
        {
            // Валидация
            if (string.IsNullOrEmpty(userRegisterDto.Name) ||
                string.IsNullOrEmpty(userRegisterDto.Login) ||
                string.IsNullOrEmpty(userRegisterDto.Password))
                throw new ArgumentException("Имя пользователя, логин и пароль обязательны.");

            if (await _userRepository.LoginExists(userRegisterDto.Login))
                throw new ArgumentException("Пользователь с таким логином уже существует.");

            // Хэширование пароля
            var (hash, salt) = _passwordHasher.HashPassword(userRegisterDto.Password);

            // Создание пользователя
            var userData = new UserDataDto
            {
                Name = userRegisterDto.Name,
                PasswordHash = hash,
                PasswordSalt = salt,
            };

            var createdUser = await _userRepository.CreateUser(userData);

            return new UserProfileDto 
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Login = createdUser.Login,
            };
        }

        public async Task<UserProfileDto?> GetProfile(int userId)
        {
            var userEntity = await _userRepository.GetUserById(userId);
            if (userEntity == null)
                return null;

            return new UserProfileDto
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Name = userEntity.Name,
            };
        }

        //public async Task UpdateUser(User user)
        //{
        //    await _userRepository.Update(user);
        //}
    }
}