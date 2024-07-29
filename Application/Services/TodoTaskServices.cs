using Application.Dto;
using Application.Exceptions;
using Application.Filters;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Utils;
using System.Globalization;

namespace Application.Services;

public class TodoTaskServices(ITodoTaskRepository todoTaskRepository, IMapper mapper) : ITodoTaskServices {

    public async Task<Result<IEnumerable<TodoTaskDto>>> GetTodoTask() {
        var t =await todoTaskRepository.GetTasksAsync();
        return Result<IEnumerable<TodoTaskDto>>.SuccessResult(mapper.Map<IEnumerable<TodoTaskDto>>(t));
    }

    public async Task<Result<TodoTaskDto>> GetTodoTasksById(string? id) {
        try
        {
            if (id is not { Length: > 0 }){
                throw new NotFoundException("id not found");
            }
            var t = await todoTaskRepository.GetTaskByIdAsync(id);
            var mapper1 = mapper.Map<TodoTaskDto>(t);
            return Result<TodoTaskDto>.SuccessResult(mapper1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new NotFoundException("Todo Not Found");
        }
    }

    public async Task<Result<TodoTaskDto>> Add(TodoTaskDto todoTaskDto) {
        var todoTask = mapper.Map<TodoTask>(todoTaskDto);

        todoTask.Code = RandomGenerator.RandomStringCode(6);
        await todoTaskRepository.CreateAsync(todoTask);
        return Result<TodoTaskDto>.SuccessResult(todoTaskDto);
    }

    public async Task<Result<TodoTaskDto>> Update(UpdateTodoTaskDto todoTaskDto, string id) {
        var todo     = await todoTaskRepository.GetTaskByIdAsync(id);
        if (todo == null){
            throw new Exception();
        }

        Console.WriteLine(todoTaskDto.ToString());

        if (!String.IsNullOrEmpty(todoTaskDto.Description)){
            todo.Description = todoTaskDto.Description;
        }
        if (!String.IsNullOrEmpty(todoTaskDto.Name)){
            todo.Name = todoTaskDto.Name;
        }
        await todoTaskRepository.UpdateAsync(todo);
        return Result<TodoTaskDto>.SuccessResult(mapper.Map<TodoTaskDto>(await GetTodoTasksById(id)));
    }

    public async Task<Result<TodoTaskDto>> UpdateProgress(string id, int? progress) {
        var todo = await todoTaskRepository.GetTaskByIdAsync(id);
        if (todo == null){
            throw new CultureNotFoundException();
        }

        var setValue = progress switch {
            < 0   => 0,
            > 100 => 100,
            null => 0,
            _     => progress.Value
        };

        todo.PercentageCompleted = setValue;

        todo.IsComplete = setValue == 100;

        await todoTaskRepository.UpdateAsync(todo);

        return Result<TodoTaskDto>.SuccessResult(mapper.Map<TodoTaskDto>(await GetTodoTasksById(id)));
    }

    public async Task<Result<Boolean>> Remove(string? id) {
        if (String.IsNullOrEmpty(id)){
            throw new Exception();
        }
        var todoTask = await todoTaskRepository.GetTaskByIdAsync(id);
        if (todoTask == null){
            throw new Exception();
        }


        try{
            await todoTaskRepository.RemoveAsync(todoTask);
            return Result<Boolean>.SuccessResult(true);
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw;
        }
    }
}