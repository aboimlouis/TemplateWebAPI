using Mapster;
using Template.Application.DTOs;
using Template.Application.Interfaces;
using Template.Domain.Interfaces;
using Template.Domain.Interfaces.Infrastructure;

namespace Template.Application.Business.TestBusiness
{
    public class TestBusiness : ITestBusiness
    {
        private readonly ITestService _testService;
        private readonly ITestPostgresRepository _testPostgresRepository;
        private readonly ITestHttpClient _testHttpClient;

        public TestBusiness(ITestService testService, ITestPostgresRepository testPostgresRepository, ITestHttpClient testHttpClient)
        {
            _testService = testService;
            _testPostgresRepository = testPostgresRepository;
            _testHttpClient = testHttpClient;
        }

        public async Task<TestDTO?> GetTest()
        {
            var repositoryTest = (await _testPostgresRepository.TestMethod())?.Adapt<TestDTO>();
            var httpTest = (await _testHttpClient.TestMethod())?.Adapt<TestDTO>();
            var test = await _testService.GetTest();
            return repositoryTest;
        }
    }
}
