using System.Text;

namespace Middlewares;

public class RequestResponseMiddleware
{
    public ILogger<RequestResponseMiddleware> Logger { get; }
    private readonly RequestDelegate _next;

    public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> logger)
    {
        Logger = logger;
        _next = Next;
    }
    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;
        //request
        Logger.LogInformation("Query: {RequestQueryString}", context.Request.QueryString); 
        MemoryStream requestBody = new MemoryStream();
        await context.Request.Body.CopyToAsync(requestBody);
        requestBody.Seek(0, SeekOrigin.Begin);
        string requestText = await new StreamReader(requestBody).ReadToEndAsync();
        var tempSteam = new MemoryStream();
        context.Response.Body = tempSteam;
        await _next.Invoke(context);//response return

        tempSteam.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(context.Response.Body, Encoding.UTF8).ReadToEndAsync();
        tempSteam.Seek(0, SeekOrigin.Begin);
        await context.Response.Body.CopyToAsync(originalBodyStream);
        //response
    }
}