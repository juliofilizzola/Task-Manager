using Application.Dto;

namespace Application.Interface;

public interface ITodoTaskServices {
    Task<IEnumerable<ITodoTaskDto>> GetTodoTask();
    Task <ITodoTaskDto> GetTodoTasksByID(string? id);
    Task <ITodoTaskDto> Add(ITodoTaskDto todoTaskDto);
    Task<ITodoTaskDto> Update(ITodoTaskDto todoTaskDto);
    Task<bool> Remove(int? id);
}