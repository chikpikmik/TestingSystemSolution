namespace TestingSystem.Core.Models
{
    public class VectorScore
    {
        public int Id { get; set; }
        public Vector Vector { get; set; }
        public Score Score { get; set; }
        public double Value { get; set; }

        public int VectorId { get; set; }
        public int ScoreId { get; set; }

    }
}
