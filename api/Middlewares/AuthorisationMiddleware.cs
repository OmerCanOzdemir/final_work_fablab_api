using System.Text;

namespace api.Middlewares
{
    public class AuthorisationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public AuthorisationMiddleware(RequestDelegate next)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

            _configuration = builder.Build();
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authorisation = context.Request.Headers["authorisation"];

            if (string.IsNullOrEmpty(authorisation)|| authorisation != _configuration.GetSection("authorisation").Value)
            {
                context.Response.StatusCode = 404;
                var error = Encoding.UTF8.GetBytes("No authorisation");
                await context.Response.Body.WriteAsync(error, 0, error.Length);
                return;
            }


            await _next(context);
        }
    }
}
