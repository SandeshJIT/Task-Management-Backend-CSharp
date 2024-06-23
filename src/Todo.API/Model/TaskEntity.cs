namespace Todo.API.Model
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }    

        public TaskEntity()
        {
            TaskName = string.Empty;
        }
    }
}