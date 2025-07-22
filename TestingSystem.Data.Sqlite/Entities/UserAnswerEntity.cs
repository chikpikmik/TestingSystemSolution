namespace TestingSystem.Data.Sqlite.Entities
{
    public class UserAnswerEntity
    {
        public int Id { get; set; }


        public AnswerOptionEntity AnswerOption { get; set; }
        public TestResultEntity TestResult { get; set; }
    }
}
