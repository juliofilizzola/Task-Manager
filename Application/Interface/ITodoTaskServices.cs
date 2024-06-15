using Application.Dto;

namespace Application.Interface;

public interface ITodoTaskServices {
    Task<IEnumerable<TodoTaskDto>> GetTodoTask();
    Task <TodoTaskDto> GetTodoTasksById(string? id);
    Task <TodoTaskDto> Add(TodoTaskDto todoTaskDto);
    Task<TodoTaskDto> Update(UpdateTodoTaskDto todoTaskDto, string id);
    Task<TodoTaskDto> UpdateProgress(string id, int? progress);
    Task<bool> Remove(string? id);
}