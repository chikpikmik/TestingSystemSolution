namespace TestingSystem.Core.Models
{
    public class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Image? Image { get; set; }

        public List<Question> Questions { get; set; }

    }
}
