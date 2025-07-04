using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Core.Models;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class VectorScoreConfiguration : IEntityTypeConfiguration<VectorScore>
    {
        public void Configure(EntityTypeBuilder<VectorScore> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(vs => vs.Vector)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(vs => vs.Score)
                .WithMany(s => s.VectorsScores)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
