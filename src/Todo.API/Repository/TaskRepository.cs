using Microsoft.EntityFrameworkCore;
using System.Net;
using Todo.API.EFCore;
using Todo.API.Exceptions;
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

        public async Task<TaskEntity?> DeleteTaskById(Guid id)
        {
            try
            {
                var task = await _dbContext.TaskEntities.FindAsync(id);
                if(task is null)    return null;
                var result = _dbContext.TaskEntities.Remove(task);
                await _dbContext.SaveChangesAsync();
                return task;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            try
            {
                var tasklist = await _dbContext.TaskEntities.ToListAsync();
                return tasklist;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
        {
            try
            {
                var task = await _dbContext.TaskEntities.FindAsync(id);
                return task;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}