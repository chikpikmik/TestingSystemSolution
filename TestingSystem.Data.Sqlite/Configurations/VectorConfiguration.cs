using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class VectorConfiguration : IEntityTypeConfiguration<Vector>
    {
        public void Configure(EntityTypeBuilder<Vector> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(v => v.Description).IsRequired(false);

        }
    }
}
