using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Core.DTOs;

namespace TestingSystem.Core.Services
{
    public interface ITestService
    {
        Task<IEnumerable<VectorDto>> GetVectorsList();
    }
}
