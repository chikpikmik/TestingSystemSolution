namespace TestingSystem.Core.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public Score Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }

        public List<UserAnswer> Answers { get; set; }
    }

}