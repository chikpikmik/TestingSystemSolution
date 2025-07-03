namespace TestingSystem.Core.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<Question> Questions { get; set; }

    }
}
