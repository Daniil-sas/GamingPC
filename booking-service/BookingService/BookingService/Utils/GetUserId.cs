namespace BookingService.Utils
{
    public static class GetUserId
    {
        private static readonly IHttpContextAccessor _contextAccessor;

        public static Guid GetCurrentUserId() => Guid.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
    }
}
