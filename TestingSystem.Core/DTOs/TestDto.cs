using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Core.DTOs
{
    public class TestDataDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        // Image
        public UserProfileDto Author { get; set; }
        public List<QuestionDto> Questions { get; set; } = new();
    }

    public class TestProfileDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        // Image
        public UserProfileDto Author { get; set; }
    }
}
