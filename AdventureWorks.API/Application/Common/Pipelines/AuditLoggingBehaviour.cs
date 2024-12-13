using System.Diagnostics;
using MediatR;

namespace AdventureWorks.API.Application.Common.Pipelines;

public class AuditLoggingBehaviour<TRequest, TResponse>(ILogger<AuditLoggingBehaviour<TRequest, TResponse>> logger) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var response = await next();
        
        stopwatch.Stop();

        logger.LogInformation(
            "Handled {RequestTypeName} [{ElapsedSeconds}s]",
            typeof(TRequest).Name,
            stopwatch.Elapsed.TotalSeconds.ToString("F3"));

        return response;
    }
}