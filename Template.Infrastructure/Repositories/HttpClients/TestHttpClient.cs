using Template.Domain.Interfaces.Infrastructure;
using Template.Domain.Models;
using Template.Infrastructure.Entities.HttpTest;

namespace Template.Infrastructure.Repositories.HttpClients
{
    public class TestHttpClient : ITestHttpClient
    {
        private readonly HttpClient _httpClient;

        public TestHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ITestModel?> TestMethod()
        {
            var response = await _httpClient.GetAsync("Test/");
            return new TestRequestModel();
        }
    }
}
