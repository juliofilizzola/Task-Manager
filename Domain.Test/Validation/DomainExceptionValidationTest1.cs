using Domain.Validation;

namespace Domain.Test.Validation;


public class DomainExceptionValidationTest1 {
    [Fact]
    public void When_method_throws_exception_if_hasError_is_true()
    {
        // Arrange
        bool   hasError = true;
        string error    = "Some error message";

        // Act & Assert
        Assert.Throws<DomainExceptionValidation>(() => DomainExceptionValidation.When(hasError, error));
    }

    [Fact]
    public void When_method_does_not_throw_exception_if_hasError_is_false()
    {
        // Arrange
        bool   hasError = false;
        string error    = "Some error message";

        var exception = Record.Exception(() => DomainExceptionValidation.When(hasError, error));
        Assert.Null(exception);
    }

    [Fact]
    public void when_method_handles_null_as_error_message()
    {
        // Arrange
        bool   hasError = true;
        string error    = null;

        // Act & Assert
        Assert.Throws<DomainExceptionValidation>(() => DomainExceptionValidation.When(hasError, error));
    }


    [Fact]
    public void HasErrorTrueWithEmptyErrorString()
    {
        // Arrange
        bool   hasError = true;
        string error    = "";

        // Act & Assert
        Assert.Throws<DomainExceptionValidation>(() => DomainExceptionValidation.When(hasError, error));
    }
}