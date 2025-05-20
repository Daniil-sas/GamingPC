using AuthService.Application.Services;
using AuthService.Contracts.Users;

namespace AuthService.Controllers
{
    public static class UsersEndopints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UserService userService)
        {
            await userService.Register(request.UserName, request.Login, request.Email, request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UserService userService)
        {
            var token = await userService.Login(request.Email, request.Password);

            //сохрнаить токен в куки
            return Results.Ok(token);
        }
    }
}
