using System.Net;
using GigaBnB.Business.DTOs;

namespace GigaBnbAPI.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e.StackTrace);
            await HandleExceptionAsync(context);
        }
    }

    private Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(new ErrorDto()
        {
            Error =
                "\"Atsiprašome\" už nesklandumus kažkoks šūdas įvyko back'e, kreipkitės į sistemos administratorių Elviną",
            Message = ":)",
        }.ToString());
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}