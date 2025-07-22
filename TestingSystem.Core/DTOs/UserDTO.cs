namespace TestingSystem.Core.DTOs
{

    // 1. Для регистрации (принимает сырые данные из UI)
    public class UserRegisterDto
    {
        public string Name { get; set; }
        // Image
        public string Login { get; set; }
        public string Password { get; set; }
    }

    // 2. Для аутентификации (логин)
    public class UserLoginDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    // 3. Для безопасного возврата данных (профиль, сессии)
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        // Image
    }

    // 4. Для внутренних операций(хранение в БД)
    public class UserDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        // Image
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }

    // 5. Для смены пароля
    //public class ChangePasswordDto
    //{
    //    public int Id { get; set; }
    //    public string OldPassword { get; set; }
    //    public string NewPassword { get; set; }
    //}
}
