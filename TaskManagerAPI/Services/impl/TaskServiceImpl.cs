using TaskManagerAPI.DTOs;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Exceptions;
using TaskManagerAPI.Mapper;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Services.impl
{
    public class TaskServiceImpl : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskServiceImpl(ITaskRepository repository) {
            this._repository = repository;
        }

        public async Task<ResponseTaskDTO> Create(CreateTaskDTO dto)
        {
            TaskEntity entity = TaskMapper.CreateDTOtoEntity(dto);

            if (await _repository.TaskExists(entity))
                throw new TaskAlreadyExistsException("Tarefa já existe!");

            return TaskMapper.EntityToDTO(await _repository.Create(entity));
        }

        public async Task Delete(long id)
        {
            if (!await _repository.TaskExistsByID(id))
                throw new TaskNotFoundException("A tarefa não foi encontrada!");

            await _repository.Delete(id);
        }

        public async Task<List<ResponseTaskDTO>> Find()
        {
            var entities = await _repository.Find();
            return entities.Select(t => TaskMapper.EntityToDTO(t)).ToList();
        }

        public async Task<ResponseTaskDTO> Update(UpdateTaskDTO dto)
        {
            TaskEntity task = TaskMapper.UpdateDTOtoEntity(dto);

            if (!await _repository.TaskExistsByID(task.Id))
                throw new TaskNotFoundException("A tarefa não foi encontrada!");

            return TaskMapper.EntityToDTO(await _repository.Update(task));
        }
    }
}
