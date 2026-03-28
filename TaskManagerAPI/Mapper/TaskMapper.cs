using TaskManagerAPI.DTOs;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Mapper
{
    public static class TaskMapper
    {

        // DTO -> Entity
        public static TaskEntity CreateDTOtoEntity(CreateTaskDTO dto) {
            return new TaskEntity
            {
                Description = dto.Description,
                Title = dto.Title,
                Instant = DateTime.UtcNow
            };
        }

        public static TaskEntity UpdateDTOtoEntity(UpdateTaskDTO dto) {
            return new TaskEntity { Id = dto.Id,
                                 Title = dto.Title,
                           Description = dto.Description
            };

        }

        // Entity -> Response DTO

        public static ResponseTaskDTO EntityToDTO(TaskEntity entity) {
            return new ResponseTaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Instant = entity.Instant.ToLocalTime()
            };
        }

    }
}
