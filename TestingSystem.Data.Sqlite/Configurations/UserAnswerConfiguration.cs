using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<UserAnswerEntity> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(ua => ua.AnswerOption)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(ua => ua.TestResult)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
