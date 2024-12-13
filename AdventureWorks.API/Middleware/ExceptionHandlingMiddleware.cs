namespace AdventureWorks.API.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate request,
    ILogger<ExceptionHandlingMiddleware> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await request(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.CompleteAsync();
        }
    }
}