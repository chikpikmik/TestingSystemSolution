using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Configurations
{
    public class ScoreConfiguration : IEntityTypeConfiguration<ScoreEntity>

    {
        public void Configure(EntityTypeBuilder<ScoreEntity> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();



            builder
                .HasMany(s => s.VectorsScores)
                .WithOne(vs => vs.Score)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
