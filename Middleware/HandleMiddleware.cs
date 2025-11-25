using Microsoft.AspNetCore.Diagnostics;

namespace MyFirstAPI.Middleware
{
    public class HandleMiddleware : IExceptionHandler
    {
        private readonly ILogger<HandleMiddleware> _logger;
        public HandleMiddleware(ILogger<HandleMiddleware> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");
            // Customize the response based on the exception type
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = "An error occurred",
                Detail = "Please try again later."
            }, cancellationToken);
            return true; // Indicate that the exception has been handled
        }
    }
}
