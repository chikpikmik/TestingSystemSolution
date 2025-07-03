namespace TestingSystem.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } // Хранить хэш!
        public string Name { get; set; }
        public List<TestResult> Results { get; set; }

    }
}
