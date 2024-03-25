using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.Entities.TestPostgres;

namespace Template.Infrastructure.Contexts
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
        : base(options)
        {
        }

        public virtual DbSet<TestEntity> TestEntity { get; set; }
    }
}
