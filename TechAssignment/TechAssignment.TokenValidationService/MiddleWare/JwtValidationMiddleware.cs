using TechAssignment.TokenValidationService.Services;

namespace TechAssignment.TokenValidationService.MiddleWare
{
    public class JwtValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ValidateService validateService)
        {
            var token = context.Request.Headers["x-auth-token"].FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing x-auth-token header");
                return;
            }

            try
            {
                if (!validateService.ValidateJwt(token))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid JWT token");
                    return;
                }
            }

            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Token validation failed: {ex.Message}");
                return;
            }

            await _next(context);
        }
    }
}
