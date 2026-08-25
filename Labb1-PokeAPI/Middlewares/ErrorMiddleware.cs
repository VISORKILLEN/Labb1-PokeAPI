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
            Console.WriteLine($"I ErrorMiddleware:{context.Request.Path}");
            await _next(context);

            Console.WriteLine($"I ErrorMiddleware:{context.Response.StatusCode}");

            if (context.Response.StatusCode == 404)
            {
                context.Items["Message"] = "Detta är inte rätt sida lilla vän";
                context.Request.Path = "/Home/Error";

                await _next(context);
            }
        }
    }
}
