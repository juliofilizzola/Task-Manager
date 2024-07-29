using Domain.Validation;

namespace Domain.tests.Validation;

public class DomainExceptionValidationTest1 {

// When method does not throw exception if hasError is false
    [Fact]
    public void does_not_throw_exception_when_hasError_is_false()
    {
        // Arrange
        bool    hasError     = false;
        String? errorMessage = "This should not be thrown";

        // Act & Assert
        var exception = Record.Exception(() => DomainExceptionValidation.When(hasError, errorMessage));
        Assert.Null(exception);
    }

// When method handles null or empty error message correctly
    [Theory]
    [InlineData("Not an error")]
    [InlineData("This should not be thrown")]
    public void throws_exception_when_error_message_is_null_or_empty(String? errorMessage)
    {
        // Arrange
        bool hasError = true;

        // Act & Assert
        var exception = Assert.Throws<DomainExceptionValidation>(() => DomainExceptionValidation.When(hasError, errorMessage));
        Assert.Equal(errorMessage, exception.Message);
    }
}