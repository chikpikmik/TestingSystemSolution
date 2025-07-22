namespace TestingSystem.Data.Sqlite.Entities
{
    public enum ChoiceType { OneChoice, MultipleChoice }
    public class QuestionEntity
    {
        public int Id { get; set; }
        
        public string Text { get; set; }

        public TestEntity Test { get; set; }

        //public ChoiceType Type { get; set; }

        public List<AnswerOptionEntity> AnswersOptions { get; set; }
        public List<ImageEntity>? Images { get; set; }
    }
}
