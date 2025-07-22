
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Repositories;

namespace TestingSystem.Core.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<IEnumerable<VectorDto>> GetVectorsList()
        {
            return await _testRepository.GetVectorsList();
        }

        //// Для обычных View
        //public TestDto GetTestForView(int id)
        //{
        //    var test = _testRepository.GetById(id);
        //    return _mapper.Map<TestDto>(test);
        //}

        //// Для HI-View
        //public TestHI GetTestForHIView(int id)
        //{
        //    var test = _testRepository.GetById(id);
        //    return _mapper.Map<TestHI>(test);
        //}
    }
}
