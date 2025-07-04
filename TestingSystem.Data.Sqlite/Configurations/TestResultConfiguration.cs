using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
    {
        public void Configure(EntityTypeBuilder<TestResult> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(tr => tr.EndTime).IsRequired(false);

            builder
                .HasMany(tr => tr.UserAnswers)
                .WithOne(ua => ua.TestResult)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(tr => tr.User)
                .WithMany(u => u.TestsResults)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(tr => tr.Test)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(tr => tr.Score)
                .WithOne(s => s.TestResult)
                .HasForeignKey<TestResult>(tr => tr.ScoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
