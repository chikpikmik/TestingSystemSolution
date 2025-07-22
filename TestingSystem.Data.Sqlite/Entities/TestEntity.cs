namespace TestingSystem.Data.Sqlite.Entities
{
    public class TestEntity
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public string? Description { get; set; }

        public UserEntity Author { get; set; }
        
        public ImageEntity? Image { get; set; }

        public List<QuestionEntity> Questions { get; set; }

    }
}
