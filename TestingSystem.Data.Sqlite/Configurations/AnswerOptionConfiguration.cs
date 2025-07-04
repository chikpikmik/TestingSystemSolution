using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
    {
        public void Configure(EntityTypeBuilder<AnswerOption> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(ao => ao.Text).HasMaxLength(100);


            builder
                .HasOne(ao => ao.Image)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(ao => ao.Question)
                .WithMany(q => q.AnswersOptions)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(ao => ao.Score)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
         
        }
    }
}
