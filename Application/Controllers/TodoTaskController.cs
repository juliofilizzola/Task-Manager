using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class TodoTaskController {
    private readonly ITodoTaskServices _todoTaskServices;

    public TodoTaskController(ITodoTaskServices services) {
        _todoTaskServices = services;
    }

    [HttpGet]
    public async Task<IEnumerable<ITodoTaskDto>> GetTask() {
        return await _todoTaskServices.GetTodoTask();
    }

    [HttpGet("{id}")]
    public async Task<ITodoTaskDto> GetTaskById(string id) {
        return await _todoTaskServices.GetTodoTasksByID(id);
    }
}