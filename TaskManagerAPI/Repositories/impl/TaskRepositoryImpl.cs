using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Repositories.impl
{
    public class TaskRepositoryImpl : ITaskRepository
    {
        private AppDbContext _context;

        public TaskRepositoryImpl(AppDbContext context) {
            this._context = context;
        }

        public async Task<TaskEntity> Create(TaskEntity entity)
        {
            await this._context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(long id)
        {
            TaskEntity? task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == id);

            if (task != null)
                _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskEntity>> Find()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<bool> TaskExists(TaskEntity entity)
        {
            return await _context.Tasks.AnyAsync(task => task.Id == entity.Id
            || task.Title == entity.Title
            || task.Description == entity.Description);
        }

        public Task<bool> TaskExistsByID(long id)
        {
            return _context.Tasks.AnyAsync(task => task.Id == id);
        }

        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            TaskEntity? task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == entity.Id);

            if (task != null)
            {
                task.Title = entity.Title;
                task.Description = entity.Description;

                await _context.SaveChangesAsync();
            }

            return task;
        }
    }
}
