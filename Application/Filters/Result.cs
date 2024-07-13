namespace Application.Filters;

public class Result<T> {
    public Boolean Success { get; }
    public T? Value { get; }
    public String? Error { get; }

    private Result(T? value, Boolean success, String? error) {
        Value = value;
        Success = success;
        Error = error;
    }

    public static Result<T> SuccessResult(T value) => new Result<T>(value, true, null);
    public static Result<T> ErrorResult(String error) => new Result<T>(default, false, error);

}