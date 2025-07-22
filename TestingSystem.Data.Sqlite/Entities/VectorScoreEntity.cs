
namespace TestingSystem.Data.Sqlite.Entities
{
    public class VectorScoreEntity
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public VectorEntity Vector { get; set; }
        public ScoreEntity Score { get; set; }

    }
}
