namespace TestingSystem.Core.Models
{
    public class Score
    {
        public int Id { get; set; }
        public List<VectorScore> VectorScores { get; set; }

        public static Score operator +(Score s1, Score s2)
        {
            var combined = s1.VectorScores
                .Concat(s2.VectorScores)
                .GroupBy(vs => vs.Vector)
                .Select(g => new VectorScore
                {
                    Vector = g.Key,
                    Value = g.Sum(vs => vs.Value)
                })
                .ToList();

            return new Score { VectorScores = combined };
        }
    }
}
