using Application.Dto;
using Application.Interface;
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
    public async Task<ActionResult> GetTaskById(string id) {
        return Ok(await _todoTaskServices.GetTodoTasksById(id));
    }

    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] TodoTaskDto todoTaskDto) {
        return Ok(await _todoTaskServices.Add(todoTaskDto));
    }

    [HttpPatch("progress/{id}")]
    public async Task<ActionResult> UpdateProgress([FromBody] UpdateTodoTaskDto todoTaskDto, string id) {
        return Ok(await _todoTaskServices.UpdateProgress(id, todoTaskDto.PercentageCompleted));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Update([FromBody] UpdateTodoTaskDto todoTaskDto, string id) {
        return Ok(await _todoTaskServices.Update(todoTaskDto, id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id) {
        return Ok(await _todoTaskServices.Remove(id));
    }
}