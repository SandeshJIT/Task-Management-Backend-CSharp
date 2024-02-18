using FluentValidation.TestHelper;
using Todo.API.Model;
using Todo.API.Validators;

namespace Todo.API.UnitTests;
public class TaskRequestValidatorTests
{
    private readonly TaskRequestValidator _validator;

    public TaskRequestValidatorTests()
    {
        _validator = new TaskRequestValidator();
    }

    [Fact]
    public void TaskName_ShouldNotBeEmpty()
    {
        // Arrange
        var request = new TaskRequest { TaskName = string.Empty };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(task => task.TaskName);
    }

    [Fact]
    public void TaskName_ShouldNotBeNull()
    {
        // Arrange
        var request = new TaskRequest { TaskName = null };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(task => task.TaskName);
    }

    [Fact]
    public void TaskName_ShouldNotExceedMaximumLength()
    {
        // Arrange
        var request = new TaskRequest { TaskName = new string('a', 256) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(task => task.TaskName);
    }
}
