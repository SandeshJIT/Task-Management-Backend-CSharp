using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Todo.API.AutoMapper;
using Todo.API.Model;
using Todo.API.Service;

namespace Todo.API.Controllers
{
    [Route("/api/todo-list/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _autoMapper;

        public TaskController(ITaskService taskService, IMapper autoMapper)
        {
            _taskService = taskService;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// Creates new task
        /// </summary>
        /// <param name="TaskRequest"></param>
        /// <returns>TaskResponse list is responsed</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] IEnumerable<TaskRequest> tasklist)
        {
            var taskModelList = _autoMapper.Map<IEnumerable<TaskEntity>>(tasklist);
            IEnumerable<TaskEntity> result = await _taskService.CreateTasksAsync(taskModelList);
            var response = _autoMapper.Map<IEnumerable<TaskResponse>>(result);
            return Ok(response);
        }
    }
}
