namespace TestingSystem.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<AnswerOption> Options { get; set; }
    }
}
