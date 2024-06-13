using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTaskController : ControllerBase {
    private readonly ITodoTaskServices _todoTaskServices;

    public TodoTaskController(ITodoTaskServices services) {
        _todoTaskServices = services;
    }

    [HttpGet]
    public async Task<ActionResult> GetTask() {
        return Ok(await _todoTaskServices.GetTodoTask());
    }

    [HttpGet("{id}")]
    public async Task<TodoTaskDto> GetTaskById(string id) {
        return await _todoTaskServices.GetTodoTasksByID(id);
    }

    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] TodoTaskDto todoTaskDto) {
        return Ok(await _todoTaskServices.Add(todoTaskDto));
    }
}