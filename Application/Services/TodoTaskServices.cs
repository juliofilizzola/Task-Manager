using Application.Dto;
using Application.Interface;
using Domain.Interfaces;

namespace Application.Services;

public class TodoTaskServices : ITodoTaskServices {
    private readonly ITaskRepository _repo;
    public TodoTaskServices(ITaskRepository taskRepository) {
        _repo = taskRepository;
    }


    public async Task<IEnumerable<ITodoTaskDto>> GetTodoTask() {
        var t =await _repo.GetTasksAsync();
    }
    public async Task<ITodoTaskDto> GetTodoTasksByID(string? id) => throw new NotImplementedException();
    public async Task<ITodoTaskDto> Add(ITodoTaskDto todoTaskDto) => throw new NotImplementedException();
    public async Task<ITodoTaskDto> Update(ITodoTaskDto todoTaskDto) => throw new NotImplementedException();
    public async Task<Boolean> Remove(Int32? id) => throw new NotImplementedException();
}