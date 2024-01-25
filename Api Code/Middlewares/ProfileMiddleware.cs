using System.Diagnostics;

namespace Api_Code.Middlewares
{
    public class ProfileMiddleware(RequestDelegate next, ILogger<ProfileMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ProfileMiddleware> _logger = logger;

        //private readonly RequestDelegate _next;
        //private readonly ILogger<ProfileMiddleware> _logger;

        //public ProfilingMiddleware(RequestDelegate next, ILogger<ProfileMiddleware> logger)
        //{
        //    _next = next;
        //    _logger = logger;
        //}
        public async Task Invoke(HttpContext context) 
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request `{context.Request.Path}` took `{stopwatch.ElapsedMilliseconds}`");
        }
    }
}
