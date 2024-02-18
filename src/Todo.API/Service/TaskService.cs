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

        public async Task<IEnumerable<TaskEntity>> CreateTasksAsync(IEnumerable<TaskEntity> tasklist)
        {
            foreach (var item in tasklist)
            {
                item.DateTime = DateTime.Now;
            }
            return await _taskRepository.CreateTaskAsync(tasklist);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }
    }
}
