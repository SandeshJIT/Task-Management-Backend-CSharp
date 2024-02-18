using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Todo.API.AutoMapper;
using Todo.API.Exceptions;
using Todo.API.Model;
using Todo.API.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("/api/todo-list/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _autoMapper;
        private readonly IValidator<IEnumerable<TaskRequest>> _validator;

        public TaskController(ITaskService taskService, IMapper autoMapper, IValidator<IEnumerable<TaskRequest>> validator)
        {
            _taskService = taskService;
            _autoMapper = autoMapper;
            _validator = validator;
        }

        /// <summary>
        /// Creates new task
        /// </summary>
        /// <param name="TaskRequest"></param>
        /// <returns>TaskResponse list is responsed</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] IEnumerable<TaskRequest> tasklist)
        {
            var validator = _validator.Validate(tasklist);
            if (!validator.IsValid)
            {
                var errors = validator.Errors.Select(e => new ErrorResponse
                {
                    ErrorCode = e.ErrorCode,
                    ErrorMessage = e.ErrorMessage
                });
                return BadRequest(errors);
            }
            var taskModelList = _autoMapper.Map<IEnumerable<TaskEntity>>(tasklist);
            IEnumerable<TaskEntity> result = await _taskService.CreateTasksAsync(taskModelList);
            var response = _autoMapper.Map<IEnumerable<TaskResponse>>(result);
            return Ok(response);
        }
        
        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <param name=""></param>
        /// <returns>TaskResponse list is responsed</returns>
        [HttpGet]
        [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTasks()
        {
            IEnumerable<TaskEntity> result = await _taskService.GetAllTasksAsync();
            var response = _autoMapper.Map<IEnumerable<TaskResponse>>(result);
            return Ok(response);
        }
    }
}
