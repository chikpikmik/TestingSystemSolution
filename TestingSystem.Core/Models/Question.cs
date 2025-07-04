namespace TestingSystem.Core.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }

        public Test Test { get; set; }
        
        public List<AnswerOption> AnswersOptions { get; set; }
        public List<Image>? Images { get; set; }
    }
}
