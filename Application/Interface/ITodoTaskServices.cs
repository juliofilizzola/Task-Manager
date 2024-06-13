using Application.Dto;

namespace Application.Interface;

public interface ITodoTaskServices {
    Task<IEnumerable<TodoTaskDto>> GetTodoTask();
    Task <TodoTaskDto> GetTodoTasksByID(string? id);
    Task <TodoTaskDto> Add(TodoTaskDto todoTaskDto);
    Task<TodoTaskDto> Update(TodoTaskDto todoTaskDto);
    Task<bool> Remove(string? id);
}