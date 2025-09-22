namespace HaalCentraal.BrpService.Middlewares;

public class AddAcceptGezagVersionHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public AddAcceptGezagVersionHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Request.Headers.Append("accept-gezag-version", "2");
        
        await _next(context);
    }
}