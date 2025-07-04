using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>

    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();



            builder
                .HasMany(s => s.VectorsScores)
                .WithOne(vs => vs.Score)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(s => s.AnswerOption)
                .WithOne(ao => ao.Score)
                .HasForeignKey<Score>(s => s.AnswerOptionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(s => s.TestResult)
                .WithOne(tr => tr.Score)
                .HasForeignKey<TestResult>(tr => tr.ScoreId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
