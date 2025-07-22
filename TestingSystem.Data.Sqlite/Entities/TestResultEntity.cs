namespace TestingSystem.Data.Sqlite.Entities
{
    public class TestResultEntity
    {
        public int Id { get; set; }
        
        
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public UserEntity User { get; set; }
        public TestEntity Test { get; set; }

        public int ScoreId { get; set; }

        // Ответы одного и того же пользователя на один и тот же тест
        public List<UserAnswerEntity> UserAnswers { get; set; }
    }

}