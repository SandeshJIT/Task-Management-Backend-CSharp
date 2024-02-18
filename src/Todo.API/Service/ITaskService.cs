using Todo.API.Model;

namespace Todo.API.Service
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> CreateTasksAsync(IEnumerable<TaskEntity> tasklist);
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity?> GetTaskByIdAsync(Guid id);
    }
}