using Application.Dto;
using Application.Filters;
using Application.Mappings;
using AutoMapper;
using Domain.Entity;
using Domain.Validation;

namespace Application.tests.Mappings;

public class DomainToDtoMappingProfileTest1 {

    // Correct mapping between TodoTask and TodoTaskDto
    [Fact]
    public void map_todo_task_to_todo_task_dto()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDtoMappingProfile>());
        var mapper = config.CreateMapper();

        var todoTask    = new TodoTask("Test Task", 50, "This is a test task");
        var todoTaskDto = mapper.Map<TodoTaskDto>(todoTask);

        Assert.Equal(todoTask.Id, todoTaskDto.Id);
        Assert.Equal(todoTask.Name, todoTaskDto.Name);
        Assert.Equal(todoTask.IsComplete, todoTaskDto.IsComplete);
    }

    // Correct mapping between TodoTaskDto and TodoTask
    [Fact]
    public void map_todo_task_dto_to_todo_task()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDtoMappingProfile>());
        var mapper = config.CreateMapper();

        var todoTaskDto = new TodoTaskDto { Id = "id test", Name = "Test Task", IsComplete = false };
        var todoTask = mapper.Map<TodoTask>(todoTaskDto);

        Assert.Equal(todoTaskDto.Id, todoTask.Id);
        Assert.Equal(todoTaskDto.Name, todoTask.Name);
        Assert.Equal(todoTaskDto.IsComplete, todoTask.IsComplete);
    }

    // Mapping with null values in TodoTaskDto
    [Fact]
    public void map_null_values_in_todotaskdto()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDtoMappingProfile>());
        var mapper = config.CreateMapper();

        var todoTaskDto = new TodoTaskDto { Id = "id test", Name = null, IsComplete = false };


        var exception = Assert.Throws<DomainExceptionValidation>(() => mapper.Map<TodoTask>(todoTaskDto));

        Assert.Equal("Invalid, Name is required", exception.Message);
    }

}