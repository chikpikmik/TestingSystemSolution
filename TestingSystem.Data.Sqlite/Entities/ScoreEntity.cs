namespace TestingSystem.Data.Sqlite.Entities
{
    public class ScoreEntity
    {
        public int Id { get; set; }

        public List<VectorScoreEntity> VectorsScores { get; set; }


        public static ScoreEntity operator +(ScoreEntity s1, ScoreEntity s2)
        {
            var combined = s1.VectorsScores
                .Concat(s2.VectorsScores)
                .GroupBy(vs => vs.Vector)
                .Select(g => new VectorScoreEntity
                {
                    Vector = g.Key,
                    Value = g.Sum(vs => vs.Value)
                })
                .ToList();

            return new ScoreEntity { VectorsScores = combined };
        }
    }
}
