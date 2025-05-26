namespace AuthService.Application.DTOs.JwtToken
{
    public record AccessToken(string Token, int ExpiriesIn);
}
