using System.ComponentModel.DataAnnotations;

namespace AuthService.Contracts.Users
{
    public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Login,
    [Required] string Email,
    [Required] string Password);
}
