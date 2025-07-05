namespace TestingSystem.Core.Models
{
    public class Score
    {
        public int Id { get; set; }

        public TestResult? TestResult { get; set; }

        public List<VectorScore> VectorsScores { get; set; }


        public static Score operator +(Score s1, Score s2)
        {
            var combined = s1.VectorsScores
                .Concat(s2.VectorsScores)
                .GroupBy(vs => vs.Vector)
                .Select(g => new VectorScore
                {
                    Vector = g.Key,
                    Value = g.Sum(vs => vs.Value)
                })
                .ToList();

            return new Score { VectorsScores = combined };
        }
    }
}
