namespace TestingSystem.Core.Models
{
    public enum ChoiceType { OneChoice, MultipleChoice }
    public class Question
    {
        public int Id { get; set; }
        
        public string Text { get; set; }

        public Test Test { get; set; }

        //public ChoiceType Type { get; set; }

        public List<AnswerOption> AnswersOptions { get; set; }
        public List<Image>? Images { get; set; }
    }
}
