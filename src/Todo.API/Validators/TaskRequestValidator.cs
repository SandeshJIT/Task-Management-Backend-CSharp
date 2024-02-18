using FluentValidation;
using Todo.API.Model;

namespace Todo.API.Validators
{
    public class TaskRequestValidator : AbstractValidator<TaskRequest>
    {
        public TaskRequestValidator() 
        {
            RuleFor(task => task.TaskName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);
            
            RuleFor(task => task.TaskDescription)
                .MaximumLength(255);
        }
    }

    public class TaskRequestCollectionValidator : AbstractValidator<IEnumerable<TaskRequest>>
    {
        public TaskRequestCollectionValidator()
        {
            RuleForEach(collection => collection)
                .SetValidator(new TaskRequestValidator());
        }
    }
}
