using System.ComponentModel.DataAnnotations;

namespace AuthService.Contracts.Users
{
    public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
}
