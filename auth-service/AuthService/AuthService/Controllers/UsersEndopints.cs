using AuthService.Application.Services;
using AuthService.Contracts.Users;

namespace AuthService.Controllers
{
    public static class UsersEndopints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/auth/register", Register);
            app.MapPost("api/auth/login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UserService userService)
        {
            await userService.Register(request.UserName, request.Login, request.Email, request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UserService userService, HttpContext context)
        {
            var token = await userService.Login(request.Email, request.Password);

            context.Response.Cookies.Append("token", token.AccessToken);
            context.Response.Cookies.Append("refresh-token", token.RefreshToken);

            return Results.Ok(token);
        }
    }
}
