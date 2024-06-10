namespace Domain.Validation;

public class DomainExceptionValidation(string err) : Exception(err) {
    public static void When(bool hasError, string error) {
        if (hasError){
            throw new DomainExceptionValidation(error);
        }
    }
}