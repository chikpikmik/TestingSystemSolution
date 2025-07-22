
using TestingSystem.Core.DTOs;

namespace TestingSystem.Core.Repositories
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestProfileDto>> GetTestProfilesList();
        Task<IEnumerable<QuestionDto>> GetQuestionsList(int TestId);
        Task<IEnumerable<VectorDto>> GetVectorsList();
        Task AddTest(TestDataDto test);
        Task AddVector(VectorDto vector);
        //Task AddUserAnswer(UserAnswerDto answer);
        //Task<TestResultDto> GetTestResult(int UserId, int TestId);
        Task<TestDataDto> GetTestById(int testId);
        Task<QuestionDto> GetQuestionById(int questionId);
    }
}
