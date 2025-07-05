namespace TestingSystem.Core.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }

        public string Text { get; set; }
        

        public Score Score { get; set; }
        public Question Question { get; set; }
        public Image? Image { get; set; }
    }
}
