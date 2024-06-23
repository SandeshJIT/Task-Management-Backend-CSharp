using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.API.Model;

namespace Todo.API.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskEntity> TaskEntities { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
