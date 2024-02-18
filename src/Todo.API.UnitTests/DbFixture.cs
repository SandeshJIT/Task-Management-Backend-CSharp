using Microsoft.EntityFrameworkCore;
using Todo.API.EFCore;

namespace Todo.API.UnitTests
{
    public class DbFixture : IDisposable
    {
        public AppDbContext DbContext { get; }

        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            DbContext = new AppDbContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}
