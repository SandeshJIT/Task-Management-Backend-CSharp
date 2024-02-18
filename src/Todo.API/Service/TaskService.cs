using Todo.API.Model;
using Todo.API.Repository;

namespace Todo.API.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskEntity>> CreateTasksAsync(IEnumerable<TaskRequest> tasklist)
        {
            return await _taskRepository.CreateTaskAsync(tasklist);
        }
    }
}
