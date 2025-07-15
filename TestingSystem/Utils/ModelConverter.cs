using TestingSystem;
using TestingSystem.Core.Models;
using TestingSystem.Core.Utils;
using TestingSystem.ViewModels;

public static class ModelConverter
{
    //private readonly ISessionManager _sessionManager;

    public static Test ToDomainModel(this TestHI hi)
    {
        return new Test
        {
            Name = hi.Name,
            Description = hi.Description,
            //Author = _sessionManager.CurrentUser,
            //Image = hi.Image,
            Questions = hi.Childrens.OfType<QuestionHI>()
                                  .Select(q => q.ToDomainModel())
                                  .ToList()
        };
    }

    public static Question ToDomainModel(this QuestionHI hi)
    {
        return new Question
        {
            Text = hi.Text,
            //Images = hi.Images,
            //AnswerOptions = hi.Childrens.OfType<AnswerOptionHI>()
            //                           .Select(a => a.ToDomainModel())
            //                           .ToList()
        };
    }

    public static AnswerOption ToDomainModel(this AnswerOptionHI hi)
    {
        hi.Childrens.OfType<VectorScoreHI>().Select(v => v.ToDomainModel());
        
        return new AnswerOption
        {
            Text = hi.Text,
            //Image = hi.Image,
            Score = hi.Score,
        };
    }

    public static VectorScore ToDomainModel(this VectorScoreHI hi)
    {
        return new VectorScore
        {
            Vector = new Vector { Name = hi.VectorName, Description=hi.VectorDescription },
            Value = hi.Value,
            Score = ((AnswerOptionHI)hi.Parent).Score
        };
    }
}