using Todo.API.Model;

namespace Todo.API.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public Task<IEnumerable<TaskEntity>> CreateTaskAsync(IEnumerable<TaskRequest> tasklist)
        {
            throw new NotImplementedException();
        }
    }
}