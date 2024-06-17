using Microsoft.AspNetCore.Builder;
namespace Application.Middlewares;


public static class ExceptionHandlingMiddlewareExtensions {
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}