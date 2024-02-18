using Todo.API.Model;

namespace Todo.API.Service
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> CreateTasksAsync(IEnumerable<TaskRequest> tasklist);
    }
}