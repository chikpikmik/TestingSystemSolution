namespace TestingSystem.Core.Models
{
    public class UserAnswer
    {
        public Guid Id { get; set; }


        public AnswerOption AnswerOption { get; set; }
        public TestResult TestResult { get; set; }
    }
}
