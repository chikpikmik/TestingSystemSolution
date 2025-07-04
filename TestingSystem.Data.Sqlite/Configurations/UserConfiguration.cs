using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(u => u.Login).IsUnique();
            builder.Property(u => u.Login).HasMaxLength(50);
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(50);


            builder
                .HasMany(u => u.TestsResults)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(u => u.Image)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
