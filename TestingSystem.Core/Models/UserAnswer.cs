namespace TestingSystem.Core.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }


        public AnswerOption AnswerOption { get; set; }
        public TestResult TestResult { get; set; }
    }
}
