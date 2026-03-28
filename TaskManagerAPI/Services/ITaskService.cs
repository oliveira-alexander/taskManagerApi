using TaskManagerAPI.DTOs;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        Task<ResponseTaskDTO> Create(CreateTaskDTO dto);
        Task Delete(long id);
        Task<List<ResponseTaskDTO>> Find();

        Task<ResponseTaskDTO> Update(UpdateTaskDTO entity);
    }
}
