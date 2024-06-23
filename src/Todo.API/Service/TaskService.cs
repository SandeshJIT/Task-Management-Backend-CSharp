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
                item.DueDate = DateTime.Now.AddDays(3);
            }
            return await _taskRepository.CreateTaskAsync(tasklist);
        }

        public async Task<TaskEntity?> DeleteTaskById(Guid id)
        {
            return await _taskRepository.DeleteTaskById(id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<TaskEntity?> ToggleStatusById(Guid id)
        {
            return await _taskRepository.ToggleStatusById(id);
        }
    }
}
