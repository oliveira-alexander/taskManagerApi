using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskEntity> Create(TaskEntity entity);
        Task<bool> TaskExists(TaskEntity entity);
        Task<bool> TaskExistsByID(long id);
        Task Delete(long id);
        Task<List<TaskEntity>> Find();
        Task<TaskEntity> Update(TaskEntity entity);
    }
}
