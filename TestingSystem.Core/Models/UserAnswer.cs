namespace TestingSystem.Core.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public AnswerOption Option { get; set; }
        public TestResult Result { get; set; }
        public int OptionId { get; set; }
        public int TestResultId { get; set; }
    }
}
