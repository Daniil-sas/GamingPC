namespace AuthService.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base($"User with such login and password does not exist") { }
    }
}
