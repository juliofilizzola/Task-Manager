using Application.Dto;
using Application.Exceptions;
using Application.Services;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Moq;

namespace Application.tests.Services;

public class TodoTaskServicesTest1 {

    // Retrieve all todo tasks successfully
    [Fact]
    public async Task retrieve_all_todo_tasks_successfully()
    {
        // Arrange
        var mockRepo   = new Mock<ITodoTaskRepository>();
        var mockMapper = new Mock<IMapper>();
        var todo       = new TodoTask("test task", 100, null);
        var todoTasks  = new List<TodoTask> { todo };
        mockRepo.Setup(repo => repo.GetTasksAsync()).ReturnsAsync(todoTasks);
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<TodoTaskDto>>(It.IsAny<IEnumerable<TodoTask>>()))
                  .Returns(new List<TodoTaskDto> { new TodoTaskDto { Id = "1", Name = "Test Task" } });
        var service = new TodoTaskServices(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await service.GetTodoTask();

        // Assert
        Assert.True(result.Success);
        Assert.Single(result.Value);
        Assert.Equal("1", result.Value.First().Id);
    }

    // Retrieve a todo task by ID successfully
    [Fact]
    public async Task retrieve_todo_task_by_id_successfully()
    {
        // Arrange
        var mockRepo   = new Mock<ITodoTaskRepository>();
        var mockMapper = new Mock<IMapper>();
        var todoTask   = new TodoTask(name: "Test Task", percentageCompleted: 100, description: "Test Task");
        mockRepo.Setup(repo => repo.GetTaskByIdAsync("1")).ReturnsAsync(todoTask);
        mockMapper.Setup(mapper => mapper.Map<TodoTaskDto>(It.IsAny<TodoTask>()))
                  .Returns(new TodoTaskDto { Id = "1", Name = "Test Task" });
        var service = new TodoTaskServices(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await service.GetTodoTasksById("1");

        // Assert
        Assert.True(result.Success);
        Assert.Equal("1", result.Value.Id);
    }

    // Retrieve a todo task with a null or empty ID
    [Fact]
    public async Task retrieve_todo_task_with_null_or_empty_id()
    {
        // Arrange
        var mockRepo = new Mock<ITodoTaskRepository>();
        var mockMapper = new Mock<IMapper>();
        var service = new TodoTaskServices(mockRepo.Object, mockMapper.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => service.GetTodoTasksById(null));
        await Assert.ThrowsAsync<NotFoundException>(() => service.GetTodoTasksById(string.Empty));
    }

}