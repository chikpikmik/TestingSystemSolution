namespace TestingSystem.Core.Models
{
    public class TestResult
    {
        public Guid Id { get; set; }
        
        
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public User User { get; set; }
        public Test Test { get; set; }
        public Score Score { get; set; } // равен сумме UserAnswer.AnswerOption.Score из UserAnswers

        public Guid ScoreId { get; set; }

        // Ответы одного и того же пользователя на один и тот же тест
        public List<UserAnswer> UserAnswers { get; set; }
    }

}