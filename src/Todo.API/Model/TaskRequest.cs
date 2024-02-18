namespace Todo.API.Model
{
    public class TaskRequest
    {
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public TaskRequest()
        {
            TaskName = string.Empty;
        }
    }
}
