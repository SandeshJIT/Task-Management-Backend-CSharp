using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Todo.API.EFCore;
using Todo.API.Exceptions;
using Todo.API.Model;
using Todo.API.Repository;

namespace Todo.API.UnitTests
{
    [Collection("DatabaseCollection")]
    public class TaskRepositoryUnitTests : IDisposable
    {
        private readonly DbFixture _fixture;
        private readonly AppDbContext _context;
        private ITaskRepository _taskRepository;
        public TaskRepositoryUnitTests(DbFixture fixture)
        {
            _fixture = fixture;
            _context = _fixture.DbContext;
            _taskRepository = new TaskRepository(_context);

        }
        [Fact]
        public async Task CreateTaskAsync_GivenTaskEntity_ShouldSaveDataInDb()
        {
            // Arrange
            var taskList = new List<TaskEntity>
            {
                new TaskEntity { TaskName = "Task 1" },
                new TaskEntity { TaskName = "Task 2" }
            };

            // Act
            await _taskRepository.CreateTaskAsync(taskList);

            // Assert
            _context.TaskEntities.Should().HaveCount(2);
            _context.TaskEntities.Select(t => t.TaskName).Should().Contain(new[] { "Task 1", "Task 2" });
        }

        [Fact]
        public async Task CreateTaskAsync_Should_Throw_ApiException_On_Database_Error()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new AppDbContext(dbContextOptions))
            {
                var repository = new TaskRepository(dbContext);

                var taskList = new List<TaskEntity>
                {
                    new TaskEntity { TaskName = null},
                    new TaskEntity { TaskName = null }
                };

                // Act
                Func<Task> action = async () => await repository.CreateTaskAsync(taskList);

                // Assert
                await action.Should().ThrowAsync<ApiException>();
            }
        }

        [Fact]
        public async Task GetAllTasksAsync_Should_Return_All_Tasks()
        {
            // Arrange

            var taskEntities = new List<TaskEntity>
            {
                new TaskEntity {TaskName = "Task 1" , TaskDescription = "Test 1" },
                new TaskEntity {TaskName = "Task 2" , TaskDescription = "Test 2"}
            };

            await _context.TaskEntities.AddRangeAsync(taskEntities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _taskRepository.GetAllTasksAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Select(t => t.TaskName).Should().Contain(new[] { "Task 1", "Task 2" });
            result.Select(t => t.TaskDescription).Should().Contain(new[] { "Test 1", "Test 2" });
        }

        [Fact]
        public async Task GetTaskByIdAsync_GivenValidId_ShouldReturnEntityAsync()
        {
            //Arrange
            var taskEntities = new List<TaskEntity>
            {
                new TaskEntity {Id = Guid.NewGuid(), TaskName = "Task 1" , TaskDescription = "Test 1" },
                new TaskEntity {Id = Guid.NewGuid(),TaskName = "Task 2" , TaskDescription = "Test 2"}
            };

            await _context.TaskEntities.AddRangeAsync(taskEntities);
            await _context.SaveChangesAsync();

            //Act
            var result = await _taskRepository.GetTaskByIdAsync(taskEntities[0].Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(taskEntities[0]);
        }

        [Fact]
        public async Task GetTaskByIdAsync_GivenInValidId_ShouldReturnNull()
        {
            //Act
            var result = await _taskRepository.GetTaskByIdAsync(Guid.NewGuid());

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteTaskById_GievnValidId_ShouldDeleteTheEntityAsync()
        {
            //Arrange
            var taskEntities = new List<TaskEntity>
            {
                new TaskEntity {Id = Guid.NewGuid(), TaskName = "Task 1" , TaskDescription = "Test 1" },
                new TaskEntity {Id = Guid.NewGuid(),TaskName = "Task 2" , TaskDescription = "Test 2"}
            };

            await _context.TaskEntities.AddRangeAsync(taskEntities);
            await _context.SaveChangesAsync();

            //Act
            var result = await _taskRepository.DeleteTaskById(taskEntities[0].Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(taskEntities[0]);
            _context.TaskEntities.Count().Should().Be(1);
            _context.TaskEntities.Should().NotContain(taskEntities[0]);


        }

        [Fact]
        public async Task ToggleStatusById_GievnValidId_ShouldToggleStatusAsync()
        {
            //Arrange
            var taskEntities = new List<TaskEntity>
            {
                new TaskEntity {Id = Guid.NewGuid(), TaskName = "Task 1" , TaskDescription = "Test 1" },
                new TaskEntity {Id = Guid.NewGuid(),TaskName = "Task 2" , TaskDescription = "Test 2"}
            };

            await _context.TaskEntities.AddRangeAsync(taskEntities);
            await _context.SaveChangesAsync();

            //Act
            var result = await _taskRepository.ToggleStatusById(taskEntities[0].Id);

            //Assert
            result.Should().NotBeNull();
            result!.Status.Should().BeTrue();
            _context.TaskEntities.FirstOrDefault(x => x.Id == taskEntities[0].Id)!.Status.Should().BeTrue();

        }

        [Fact]
        public async Task ToggleStatusById_GievnInValidId_ShouldReturnNull()
        {
            //Act
            var result = await _taskRepository.ToggleStatusById(Guid.NewGuid());

            //Assert
            result.Should().BeNull();

        }

        public void Dispose()
        {
            _context.Database.EnsureDeletedAsync().Wait();
        }
    }
}
