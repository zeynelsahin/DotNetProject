namespace Middlewares;

public class ExceptionHandlerMiddleware
{
    public ILogger<ExceptionHandlerMiddleware> Logger { get; }
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        Logger = logger;
        _next = Next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception exception)
        {
            Logger.LogError(exception.Message);
        }
    }
}