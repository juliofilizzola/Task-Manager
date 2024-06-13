using Domain.Entity;

namespace Domain.Interfaces;

public interface ITodoTaskRepository {
    Task<IEnumerable<TodoTask>> GetTasksAsync();
    Task<TodoTask> GetTaskByIdAsync(string? id);
    Task<TodoTask> CreateAsync(TodoTask todoTask);
    Task<TodoTask> UpdateAsync(TodoTask todoTask);
    Task<TodoTask> RemoveAsync(TodoTask todoTask);
}