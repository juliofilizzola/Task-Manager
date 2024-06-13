using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Random=Domain.Utils.Random;

namespace Application.Services;

public class TodoTaskServices : ITodoTaskServices {
    private readonly ITodoTaskRepository _repo;
    private readonly IMapper         _mapper;
    public TodoTaskServices(ITodoTaskRepository todoTaskRepository, IMapper mapper) {
        _repo = todoTaskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoTaskDto>> GetTodoTask() {
        var t =await _repo.GetTasksAsync();
        return _mapper.Map<IEnumerable<TodoTaskDto>>(t);
    }

    public async Task<TodoTaskDto> GetTodoTasksByID(string? id) {
        var t = await _repo.GetTaskByIdAsync(id);
        if (t == null){
            throw new Exception();
        }

        return _mapper.Map<TodoTaskDto>(t);
    }

    public async Task<TodoTaskDto> Add(TodoTaskDto todoTaskDto) {
        var todoTask = _mapper.Map<TodoTask>(todoTaskDto);

        todoTask.Code = Random.RandomStringCode(6);
        await _repo.CreateAsync(todoTask);
        return todoTaskDto;
    }

    public async Task<TodoTaskDto> Update(TodoTaskDto todoTaskDto) {
        var todoTask = _mapper.Map<TodoTask>(todoTaskDto);
        await _repo.UpdateAsync(todoTask);
        return todoTaskDto;
    }

    public async Task<Boolean> Remove(string? id) {
        if (String.IsNullOrEmpty(id)){
            throw new Exception();
        }
        var todoTask = _repo.GetTaskByIdAsync(id);
        if (todoTask == null){
            throw new Exception();
        }

        var todoTaskRemove = _mapper.Map<TodoTask>(todoTask);

        try{
            await _repo.UpdateAsync(todoTaskRemove);
            return true;
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw;
        }
    }
}