using Forum.Infrastructure.Identity.Jwt;
using Forum.Infrastructure.Identity.Token;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Forum.Infrastructure.MiddleWare
{
    public class JwtProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtUtils _jwtUtils;

        public JwtProviderMiddleware(RequestDelegate next, IJwtUtils jwtUtils)
        {
            _next = next;
            _jwtUtils = jwtUtils;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);


            var token = _jwtUtils.ValidateToken(context.Request.Headers["x-auth-token"].FirstOrDefault());

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;

            var response = new
            {
                //Token = token,
                Message = "Authenticated successfully"
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);

        }

    }
}
