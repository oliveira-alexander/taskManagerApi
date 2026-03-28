using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Mapper;

namespace TaskManagerAPITests.Mapper
{
    public class TaskMapperTests
    {

        [Fact]
        public void Mapper_ShouldReturnTaskEntity_FromCreateTaskDTO() {
            // Arrange
            CreateTaskDTO dto = new CreateTaskDTO
            {
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            };

            // Act
            var entity = TaskMapper.CreateDTOtoEntity(dto);

            // Assert
            Assert.Matches(dto.Title, entity.Title);
            Assert.Matches(dto.Description, entity.Description);
        }

        [Fact]
        public void Mapper_ShouldReturnTaskEntity_FromUpdateTaskDTO() {
            // Arrange
            UpdateTaskDTO dto = new UpdateTaskDTO
            {
                Id = 1,
                Title = "Tarefa A",
                Description = "Descrição Tarefa A"
            };

            // Act
            var entity = TaskMapper.UpdateDTOtoEntity(dto);

            // Assert
            Assert.Equal(dto.Id, entity.Id);
            Assert.Matches(dto.Title, entity.Title);
            Assert.Matches(dto.Description, entity.Description);
        }

        [Fact]
        public void Mapper_ShouldReturnResponseTaskDTO_FromTaskEntity() {
            // Arrange
            TaskEntity entity = new TaskEntity
            {
                Id = 1,
                Title = "Tarefa A",
                Description = "Descrição Tarefa A",
                Instant = DateTime.Today
            };

            // Act
            var response = TaskMapper.EntityToDTO(entity);

            // Assert
            Assert.Equal(entity.Id, response.Id);
            Assert.Matches(entity.Title, response.Title);
            Assert.Matches(entity.Description, response.Description);
            Assert.True(response.Instant == entity.Instant);
        }
    }
}
