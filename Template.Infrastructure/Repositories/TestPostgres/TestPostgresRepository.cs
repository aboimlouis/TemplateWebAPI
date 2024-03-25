using Microsoft.EntityFrameworkCore;
using Template.Domain.Interfaces.Infrastructure;
using Template.Domain.Models;
using Template.Infrastructure.Contexts;
using Template.Infrastructure.Entities.TestPostgres;

namespace Template.Infrastructure.Repositories.TestPostgres
{
    public class TestPostgresRepository : ITestPostgresRepository
    {
        private TestContext _context { get; set; }
        public TestPostgresRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<ITestModel?> TestMethod()
        {
            var test = await _context.TestEntity.Where(x => x.Id == 1).FirstOrDefaultAsync();
            return test;
        }
    }
}
