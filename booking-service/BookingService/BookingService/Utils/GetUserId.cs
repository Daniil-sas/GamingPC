namespace BookingService.Utils
{
    public static class GetUserId
    {
        private static readonly IHttpContextAccessor _contextAccessor;

        public static Guid GetCurrentUser() => Guid.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
    }
}
