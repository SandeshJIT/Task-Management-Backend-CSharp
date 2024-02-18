using Microsoft.AspNetCore.Mvc;
using Todo.API.Model;

namespace Todo.API.Controllers
{
    [Route("/api/todo-list/task")]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] IEnumerable<TaskRequest> tasklist)
        {
            foreach (var task in tasklist)
            {
                Console.WriteLine(task.TaskName);
            }
            return Ok();
        }
    }
}
