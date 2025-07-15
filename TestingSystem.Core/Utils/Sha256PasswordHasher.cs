using System.Security.Cryptography;
using System.Text;

namespace TestingSystem.Core.Utils { 
    public class Sha256PasswordHasher : IPasswordHasher
    {
        public (string Hash, string Salt) HashPassword(string password)
        {
            // Генерируем случайную соль
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Хэшируем пароль с солью
            string hash = HashPassword(password, salt);

            return (hash, salt);
        }

        public string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (var sha256 = SHA256.Create())
            {
                // Объединяем соль и пароль
                byte[] saltedPassword = new byte[saltBytes.Length + passwordBytes.Length];
                Array.Copy(saltBytes, 0, saltedPassword, 0, saltBytes.Length);
                Array.Copy(passwordBytes, 0, saltedPassword, saltBytes.Length, passwordBytes.Length);

                // Вычисляем хэш
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            string newHash = HashPassword(password, salt);
            return newHash.Equals(hash);
        }
    }
}