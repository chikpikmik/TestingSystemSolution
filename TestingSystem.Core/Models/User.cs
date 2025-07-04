namespace TestingSystem.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; } // Хранить хэш!
        public string Name { get; set; }

        public Image? Image { get; set; }

        public List<TestResult> TestsResults { get; set; }

    }
}
