using Application.Dto;
using Application.Filters;

namespace Application.Interface;

public interface ITodoTaskServices {
    Task<Result<IEnumerable<TodoTaskDto>>> GetTodoTask();
    Task <Result<TodoTaskDto>> GetTodoTasksById(string? id);
    Task <Result<TodoTaskDto>> Add(TodoTaskDto todoTaskDto);
    Task<Result<TodoTaskDto>> Update(UpdateTodoTaskDto todoTaskDto, string id);
    Task<Result<TodoTaskDto>> UpdateProgress(string id, int? progress);
    Task<Result<bool>> Remove(string? id);
}