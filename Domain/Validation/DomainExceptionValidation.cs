namespace Domain.Validation;

public class DomainExceptionValidation(string err) : Exception(err) {
    public static void When(bool hasError, String? error) {
        if (hasError){
            throw new DomainExceptionValidation(error ?? "This should not be thrown");
        }
    }
}