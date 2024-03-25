using Template.Domain.Interfaces;
using Template.Domain.Interfaces.Infrastructure;
using Template.Domain.Models;

namespace Template.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestPostgresRepository _testPostgresRepository;
        public TestService(ITestPostgresRepository testPostgresRepository)
        {
            _testPostgresRepository = testPostgresRepository;
        }
        public async Task<bool> GetTest()
        {
            var teste = await _testPostgresRepository.TestMethod() as TestModel;
            await Task.Delay(1000);
            return true;
        }
    }
}
