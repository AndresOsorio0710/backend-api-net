using System.Diagnostics;

namespace Backend.API.Middlewares
{
    public class EjemploMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public EjemploMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(EjemploMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            Guid traceId = Guid.NewGuid();
            _logger.LogTrace($"Request{traceId} iniciada");
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            await _next(context);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
            _logger.LogDebug($"La Rquest {traceId} ha llevado {elapsedTime}");
        }
    }
}
