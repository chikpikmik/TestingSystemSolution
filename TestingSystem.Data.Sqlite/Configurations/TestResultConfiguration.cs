using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class TestResultConfiguration : IEntityTypeConfiguration<TestResultEntity>
    {
        public void Configure(EntityTypeBuilder<TestResultEntity> builder)
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
        }
    }
}
