using AuthService.Application.Services;

namespace AuthService.Controllers
{
    public static class TokenUpdateEndpoints
    {
        public static IEndpointRouteBuilder MapTokenUpdateEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet($"refresh-token", UpdateToken);
            return builder;
        }

        private static async Task<IResult> UpdateToken(HttpContext context, UpdateTokenService updateTokenService)
        {
            if (!context.Request.Cookies.TryGetValue("refresh-token", out var refreshToken))
            {
                return Results.Unauthorized();
            }

            var token = await updateTokenService.UpdateTokens(refreshToken);

            if (token == null)
            {
                return Results.Unauthorized();
            }

            context.Response.Cookies.Delete("token");
            context.Response.Cookies.Delete("refresh-token");

            context.Response.Cookies.Append("token", token.AccessToken);
            context.Response.Cookies.Append("refresh-token", token.RefreshToken);

            return Results.Ok(token);
        }
    }
}
