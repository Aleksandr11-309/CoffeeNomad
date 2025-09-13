namespace CoffeeNomad.WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    context.Response.Redirect("/page/404");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при обработке запроса");

                // Обработка 500 ошибок
                context.Response.Redirect("/page/504");
            }
        }
    }
}
