using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Exceptions;
using TaskManagerAPI.Repositories;
using TaskManagerAPI.Repositories.impl;
using TaskManagerAPI.Services;
using TaskManagerAPI.Services.impl;

namespace TaskManagerAPITests.Services
{
    public class TaskServiceTests
    {
        private readonly ITaskService _service;
        private readonly ITaskRepository _repository;
        private readonly AppDbContext _context;

        private AppDbContext CreateDB()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        public TaskServiceTests() {
            this._context = CreateDB();
            this._repository = new TaskRepositoryImpl(_context);
            this._service = new TaskServiceImpl(_repository);
        }

        [Fact]
        public async Task CreateTask_ShouldCreate_Successfully()
        {
            // Arrange

            CreateTaskDTO createTask = new CreateTaskDTO
            {
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            };

            ResponseTaskDTO response = new ResponseTaskDTO
            {
                Id = 1,
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            };

            // Act
            ResponseTaskDTO assertTask = await _service.Create(createTask);

            // Assert
            Assert.Equal(response.Id, assertTask.Id);
            Assert.Matches(response.Title, assertTask.Title);
            Assert.Matches(response.Description, assertTask.Description);
        }

        [Fact]
        public async Task CreateTask_ShouldThrow_TaskAlreadyExistsException()
        {
            // Arrange

            CreateTaskDTO createTask = new CreateTaskDTO
            {
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            };

            await _service.Create(createTask);

            // Assert
            await Assert.ThrowsAsync<TaskAlreadyExistsException>(() => _service.Create(createTask));
        }

        [Fact]
        public async Task DeleteTask_ShouldDelete_Successfully() {
            // Arrange
            await _repository.Create(new TaskManagerAPI.Entities.TaskEntity
            {
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            });

            // Act
            await _service.Delete(1);
            var task = await _repository.Find();
            var taskExiste = task.Any(t => t.Id == 1);

            // Assert
            Assert.False(taskExiste);
        }

        [Fact]
        public async Task DeleteTask_ShouldThrow_TaskNotFoundException() {
            // Act + Assert
            await Assert.ThrowsAsync<TaskNotFoundException>(() => _service.Delete(100));
        }

        [Fact]
        public async Task UpdateTask_ShouldUpdate_Successfully() {
            // Arrange

            TaskEntity originalTask = new TaskManagerAPI.Entities.TaskEntity
            {
                Title = "Tarefa A",
                Description = "Descrição Tarefa A",
                Instant = DateTime.Today
            };

            await _repository.Create(originalTask);

            UpdateTaskDTO updatingTask = new UpdateTaskDTO {
                Id = 1,
                Title = "Tarefa A - Alterada",
                Description = "Descrição Tarefa A - Alterada",
            };

            // Act
            var updatedTask = await _service.Update(updatingTask);

            // Assert
            Assert.Equal(updatingTask.Id, updatedTask.Id);
            Assert.Matches(updatingTask.Title, updatedTask.Title);
            Assert.Matches(updatingTask.Description, updatedTask.Description);
        }

        [Fact]
        public async Task UpdateTask_ShouldThrow_TaskNotFoundException() {

            // Arrange
            UpdateTaskDTO updatingTask = new UpdateTaskDTO {
                 Id = 1,
                Title = "Tarefa A - Alterada",
                Description = "Descrição Tarefa A - Alterada",
            };

        // Act + Assert
        await Assert.ThrowsAsync<TaskNotFoundException>(() => _service.Update(updatingTask));
        
        }
    }
}
