namespace Labb1_PokeAPI.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // This method is called for each HTTP request and allows the middleware to process the request and response.
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                context.Items["Message"] = "Pokemon kunde inte hittas ☹";
                context.Request.Path = "/Home/Error";

                context.Response.StatusCode = 200;

                await _next(context);
            }
        }
    }
}
