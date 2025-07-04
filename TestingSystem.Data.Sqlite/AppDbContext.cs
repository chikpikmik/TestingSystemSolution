using Microsoft.EntityFrameworkCore;
using TestingSystem.Core.Models;
using TestingSystem.Data.Sqlite.Configurations;

namespace TestingSystem.Data.Sqlite
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswersOptions { get; set; }
        public DbSet<TestResult> TestsResults { get; set; }
        public DbSet<UserAnswer> UsersAnswers { get; set; }
        public DbSet<Vector> Vectors { get; set; }
        public DbSet<VectorScore> VectorsScores { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Image> Images { get; set; }


        public AppDbContext()
        {
            SQLitePCL.Batteries.Init();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new TestResultConfiguration());
            modelBuilder.ApplyConfiguration(new UserAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VectorConfiguration());
            modelBuilder.ApplyConfiguration(new VectorScoreConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
