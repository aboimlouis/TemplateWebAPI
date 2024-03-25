using Template.Domain.Models;

namespace Template.Domain.Interfaces.Infrastructure
{
    public interface ITestHttpClient
    {
        Task<ITestModel?> TestMethod();
    }
}
