using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Repositories;
using TestingSystem.Data.Sqlite.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace TestingSystem.Data.Sqlite.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestRepository(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TestProfileDto>> GetTestProfilesList()
        {
            return _mapper.Map<IEnumerable<TestProfileDto>>(
                await _context.Tests
                .AsNoTracking()
                .ToListAsync()
                );
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsList(int testId)
        {
            return _mapper.Map<IEnumerable<QuestionDto>>(
                await _context.Questions
                .Where(q => q.Test.Id == testId)
                .AsNoTracking()
                .ToListAsync()
                );
        }

        public async Task<IEnumerable<VectorDto>> GetVectorsList()
        {
            return _mapper.Map<IEnumerable<VectorDto>>(
                await _context.Vectors
                .AsNoTracking()
                .ToListAsync()
                );
        }

        public async Task AddTest(TestDataDto test)
        {
            await _context.Tests.AddAsync(
                _mapper.Map<TestEntity>(test)
                );

            await _context.SaveChangesAsync();
        }

        public async Task AddVector(VectorDto vector)
        {
            await _context.Vectors.AddAsync(
                _mapper.Map<VectorEntity>(vector)
                );

            await _context.SaveChangesAsync();
        }

        //public async Task AddUserAnswer(UserAnswerDto answer)
        //{
        //    await _context.UsersAnswers.AddAsync(answer);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<TestResultDto> GetTestResult(int userId, int testId)
        //{
        //    return await _context.TestsResults
        //        .FirstOrDefaultAsync(r => r.User.Id == userId && r.Test.Id == testId);
        //}

        public async Task<TestDataDto> GetTestById(int testId)
        {
            return _mapper.Map<TestDataDto>(
                await _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == testId)
                );
        }

        public async Task<QuestionDto> GetQuestionById(int questionId)
        {
            return _mapper.Map<QuestionDto>(
                await _context.Questions
                .FirstOrDefaultAsync(q => q.Id == questionId)
                );
        }
    
    }
}