using System.Net;
using Todo.API.EFCore;
using Todo.API.Model;

namespace Todo.API.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskEntity>> CreateTaskAsync(IEnumerable<TaskEntity> tasklist)
        {
            try
            {
                await _dbContext.TaskEntities.AddRangeAsync(tasklist);
                await _dbContext.SaveChangesAsync();
                return tasklist;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}