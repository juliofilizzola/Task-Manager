namespace Application.Filters;

public class Result<T> {
    public bool Success { get; }
    public T? Value { get; }
    public string? Error { get; }

    private Result(T? value, bool success, string? error) {
        Value = value;
        Success = success;
        Error = error;
    }

    public static Result<T> SuccessResult(T value) => new Result<T>(value, true, null);
    public static Result<T> ErrorResult(string error) => new Result<T>(default, false, error);

}