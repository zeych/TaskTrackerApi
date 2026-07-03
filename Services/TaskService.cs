using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Create(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            return task;
        }

        public TaskItem? Update(int id, TaskItem task)
        {
            var existing = _tasks.FirstOrDefault(t => t.Id == id);
            if (existing == null) return null;
            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.Status = task.Status;
            return existing;
        }

        public bool Delete(int id)
        {
            return _tasks.RemoveAll(t => t.Id == id) > 0;
        }
    }
}
