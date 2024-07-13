using Application.Filters;

namespace Application.tests.Filters;

public class ResultsTest1 {

// Creating a successful result with a non-null value
    [Fact]
    public void create_successful_result_with_non_null_value() {
        // Arrange
        var expectedValue = "TestValue";

        // Act
        var result = Result<String>.SuccessResult(expectedValue);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(expectedValue, result.Value);
        Assert.Null(result.Error);
    }

// Creating a successful result with a null value
    [Fact]
    public void create_successful_result_with_null_value() {
        // Arrange
        string? expectedValue = null;

        // Act
        var result = Result<string>.SuccessResult(expectedValue);

        // Assert
        Assert.True(result.Success);
        Assert.Null(result.Value);
        Assert.Null(result.Error);
    }

// Creating an error result with a null error message
    [Fact]
    public void create_error_result_with_null_error_message() {
        // Arrange
        string? expectedError = null;

        // Act
        var result = Result<string>.ErrorResult(expectedError);

        // Assert
        Assert.False(result.Success);
        Assert.Null(result.Value);
        Assert.Null(result.Error);
    }

// Creating an error result with a non-null error message
    [Fact]
    public void create_error_result_with_non_null_error_message() {
        // Arrange
        string? expectedError = "TestError";

        // Act
        var result = Result<string>.ErrorResult(expectedError);

        // Assert
        Assert.False(result.Success);
        Assert.Null(result.Value);
        Assert.Equal(expectedError, result.Error);
    }
}