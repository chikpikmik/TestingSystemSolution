namespace TestingSystem.Data.Sqlite.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Login { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        

        public ImageEntity? Image { get; set; }

        public List<TestResultEntity> TestsResults { get; set; }

    }
}
