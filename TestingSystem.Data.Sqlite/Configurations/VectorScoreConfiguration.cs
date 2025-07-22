using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class VectorScoreConfiguration : IEntityTypeConfiguration<VectorScoreEntity>
    {
        public void Configure(EntityTypeBuilder<VectorScoreEntity> builder)
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
