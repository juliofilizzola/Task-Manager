namespace Domain.Tests.Utils;

public class RandomTest1 {

// Generates a string of specified length
    [Fact]
    public void generates_string_of_specified_length()
    {
        // Arrange
        int length = 10;

        string result = Domain.Utils.RandomGenerator.RandomStringCode(length);

        // Assert
        Assert.Equal(length, result.Length);
    }
}