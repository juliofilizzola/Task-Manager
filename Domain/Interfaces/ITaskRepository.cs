using Domain.Entity;

namespace Domain.Interfaces;

public interface ITaskRepository {
    Task<IEnumerable<TodoTask>> GetTasksAsync();
    Task<TodoTask> GetTaskByIdAsync(int? id);
    Task<TodoTask> CreateAsync(TodoTask todoTask);
    Task<TodoTask> UpdateAsync(TodoTask todoTask);
    Task<TodoTask> RemoveAsync(TodoTask todoTask);
}