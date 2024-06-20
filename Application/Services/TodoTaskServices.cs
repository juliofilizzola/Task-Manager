using Application.Dto;
using Application.Exceptions;
using Application.Filters;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using System.Globalization;
using Random=Domain.Utils.Random;

namespace Application.Services;

public class TodoTaskServices : ITodoTaskServices {
    private readonly ITodoTaskRepository _repo;
    private readonly IMapper         _mapper;
    public TodoTaskServices(ITodoTaskRepository todoTaskRepository, IMapper mapper) {
        _repo = todoTaskRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<TodoTaskDto>>> GetTodoTask() {
        var t =await _repo.GetTasksAsync();
        try{
            return Result<IEnumerable<TodoTaskDto>>.SuccessResult(_mapper.Map<IEnumerable<TodoTaskDto>>(t));
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw new BadRequestException("Error in find todos");
        }
    }

    public async Task<Result<TodoTaskDto>> GetTodoTasksById(string? id) {
        try
        {
            var t = await _repo.GetTaskByIdAsync(id);
            var mapper = _mapper.Map<TodoTaskDto>(t);
            return Result<TodoTaskDto>.SuccessResult(mapper);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new NotFoundException("Todo Not Found");
        }
    }

    public async Task<Result<TodoTaskDto>> Add(TodoTaskDto todoTaskDto) {
        var todoTask = _mapper.Map<TodoTask>(todoTaskDto);

        todoTask.Code = Random.RandomStringCode(6);
        try{
            await _repo.CreateAsync(todoTask);
            return Result<TodoTaskDto>.SuccessResult(todoTaskDto);
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw new BadRequestException("Error in create todo");
        }
    }

    public async Task<Result<TodoTaskDto>> Update(UpdateTodoTaskDto todoTaskDto, string id) {
        var todo     = await _repo.GetTaskByIdAsync(id);
        if (todo == null){
            throw new NotFoundException("Todo Not Found");
        }

        if (!String.IsNullOrEmpty(todoTaskDto.Description)){
            todo.Description = todoTaskDto.Description;
        }
        if (!String.IsNullOrEmpty(todoTaskDto.Name)){
            todo.Name = todoTaskDto.Name;
        }
        try{
            await _repo.UpdateAsync(todo);
            return Result<TodoTaskDto>.SuccessResult(_mapper.Map<TodoTaskDto>(await GetTodoTasksById(id)));
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw new BadRequestException("Error in update todo");
        }
    }

    public async Task<Result<TodoTaskDto>> UpdateProgress(string id, int? progress) {
        var todo = await _repo.GetTaskByIdAsync(id);

        if (todo == null){
            throw new NotFoundException("Todo Not Found");
        }

        var setValue = progress switch {
            < 0   => 0,
            > 100 => 100,
            null => 0,
            _     => progress.Value
        };

        todo.PercentageCompleted = setValue;

        todo.IsComplete = setValue == 100;

        try{
            await _repo.UpdateAsync(todo);

            return Result<TodoTaskDto>.SuccessResult(_mapper.Map<TodoTaskDto>(await GetTodoTasksById(id)));
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw new BadRequestException($"error: ${e}");
        }
    }

    public async Task<Result<bool>> Remove(string? id) {
        if (String.IsNullOrEmpty(id)){
            throw new Exception();
        }
        var todoTask = await _repo.GetTaskByIdAsync(id);
        if (todoTask == null){
            throw new NotFoundException("Todo NotFound");
        }

        try{
            await _repo.RemoveAsync(todoTask);
            return Result<bool>.SuccessResult(true);
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw new BadRequestException($"error: ${e}");
        }
    }
}