namespace WebApplication1.Middleware
{
    public class ManejadorErrores
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorErrores> _logger;

        public ManejadorErrores(RequestDelegate next, ILogger<ManejadorErrores> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error no Controlado");
                ctx.Response.StatusCode = 500;
                await ctx.Response.WriteAsJsonAsync(new { error = "Error interno del servidor" });
            }
        }
    }
}
