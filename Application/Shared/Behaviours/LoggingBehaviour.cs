using Domain.Shared.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var startTimeUtc = DateTime.UtcNow;
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Starting handling of {@RequestName} at {@StartTimeUtc}", 
            requestName,
            startTimeUtc);
        try
        {
            var result = await next();
            _logger.LogInformation("Ended handling of {RequestName}. Took {TimeElapsed}ms", 
                requestName, 
                DateTime.Now - startTimeUtc);
            return result;
        } catch (Exception ex)
            when (ex.InnerException is not DomainException)
        {
            _logger.LogError("An error ({ExceptionName}) occured handling {RequestName} at {Timestamp}. {ExceptionMessage}", 
                ex.GetType().Name,
                requestName,
                DateTime.Now,
                ex.Message);
            throw;
        }
    }
}
