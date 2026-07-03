using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Create(TaskItem task);
        TaskItem? Update(int id, TaskItem task);
        bool Delete(int id);
    }
}
