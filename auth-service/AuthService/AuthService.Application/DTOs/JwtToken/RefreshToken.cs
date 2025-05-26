namespace AuthService.Application.DTOs.JwtToken
{
    public record RefreshToken(string Token, TimeSpan ExpiriesIn);
}
