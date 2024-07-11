using Domain.Entity;
using Domain.Validation;
using System;
using Xunit;

namespace Domain.Test.Entity;

public class TodoTaskTest1
{
    [Fact]
    public void test_constructor_initialization()
    {
        // Arrange
        string name                = "Test Task";
        int    percentageCompleted = 100;
        string description         = "This is a test task";

        // Act
        TodoTask task = new TodoTask(name, percentageCompleted, description);

        // Assert
        Assert.Equal(name, task.Name);
        Assert.Equal(description, task.Description);
        Assert.Equal(percentageCompleted, task.PercentageCompleted);
        Assert.True(task.IsComplete);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ab")]
    public void test_validate_domain_exceptions(string invalidName)
    {
        // Arrange
        string description = "This is a test task";

        // Act & Assert
        Assert.Throws<DomainExceptionValidation>(() => new TodoTask(invalidName, 50, description));
    }

    [Theory]
    [InlineData(-10, 0)]
    [InlineData(50, 50)]
    [InlineData(150, 100)]
    public void test_validate_percentage(int inputPercentage, int expectedPercentage)
    {
        // Arrange
        TodoTask task = new TodoTask("Test Task", inputPercentage, "This is a test task");

        // Act
        int validatedPercentage = task.PercentageCompleted;

        // Assert
        Assert.Equal(expectedPercentage, validatedPercentage);
    }

    [Theory]
    [InlineData(100)] // []
    public void test_completed_task(int inputPercentage)
    {
        // Arrange
        TodoTask task = new TodoTask("Test Task", inputPercentage, "This is a test task");


        // Assert
        Assert.True(task.IsComplete);
    }
}