using Domain.Entity;
using Domain.Utils;

namespace Domain.Tests.Entity;

public class BaseTest1 {

// Id is generated automatically upon object creation
    [Fact]
    public void id_is_generated_automatically_upon_object_creation()
    {
        // Arrange
        var baseObject = new Base();

        baseObject.Id = RandomGenerator.RandomStringCode(32);

        // Act
        var id = baseObject.Id;

        // Assert
        Assert.NotNull(id);
    }

    [Fact]
    public void create_at_is_generated_automatically_upon_object_creation() {
        // Arrange
        var baseObject = new Base();

        // Act
        var createAt = baseObject.CreateAt;

        // Assert
        Assert.NotNull(createAt);
    }
}