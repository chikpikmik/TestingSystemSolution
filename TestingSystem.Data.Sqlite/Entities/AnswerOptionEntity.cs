
namespace TestingSystem.Data.Sqlite.Entities
{
    public class AnswerOptionEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }
        

        public ScoreEntity Score { get; set; }
        public QuestionEntity Question { get; set; }
        public ImageEntity? Image { get; set; }
    }
}
