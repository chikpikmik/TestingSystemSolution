using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(q => q.Text).HasMaxLength(100);

            builder
                .HasMany(q => q.AnswersOptions)
                .WithOne(ao => ao.Question)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(q => q.Images)
                .WithMany();
            builder
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
