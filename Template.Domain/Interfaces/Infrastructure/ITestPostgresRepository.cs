using Template.Domain.Models;

namespace Template.Domain.Interfaces.Infrastructure
{
    public interface ITestPostgresRepository
    {
        Task<ITestModel?> TestMethod();
    }
}
