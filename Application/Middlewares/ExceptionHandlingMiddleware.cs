using Application.Exceptions;

namespace Application.Middlewares;

public class ExceptionHandlingMiddleware {

    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception e) {
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception is NotFoundException ? StatusCodes.Status404NotFound : StatusCodes.Status500InternalServerError;

        var result = new { message = exception.Message };
        return context.Response.WriteAsJsonAsync(result);
    }
}