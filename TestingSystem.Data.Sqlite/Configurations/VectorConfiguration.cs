using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class VectorConfiguration : IEntityTypeConfiguration<VectorEntity>
    {
        public void Configure(EntityTypeBuilder<VectorEntity> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(v => v.Description).IsRequired(false);
            builder.Property(v => v.Description).HasMaxLength(100);
            builder.HasIndex(v => v.Name).IsUnique();

        }
    }
}
