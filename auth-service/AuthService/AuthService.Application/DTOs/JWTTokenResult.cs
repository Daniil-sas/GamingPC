namespace AuthService.Application.DTOs
{
    public record JWTTokenResult(
        string AccessToken,
        string RefreshToken);
}
