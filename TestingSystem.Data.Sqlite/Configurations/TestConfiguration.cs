using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(200).IsRequired(false);


            builder
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(q => q.Image)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
