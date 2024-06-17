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

        context.Response.StatusCode = HandlerExceptionStatusCode(exception);

        var result = new { message = exception.Message };

        return context.Response.WriteAsJsonAsync(result);
    }

    private static int HandlerExceptionStatusCode(Exception e) {
        return e switch
        {
            NotFoundException   => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            _                   => StatusCodes.Status500InternalServerError
        };
    }
}