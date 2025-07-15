namespace TestingSystem.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Login { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        

        public Image? Image { get; set; }

        public List<TestResult> TestsResults { get; set; }

    }
}
