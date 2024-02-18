using Todo.API.Model;

namespace Todo.API.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> CreateTaskAsync(IEnumerable<TaskEntity> tasklist);
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity?> GetTaskByIdAsync(Guid id);
    }
}