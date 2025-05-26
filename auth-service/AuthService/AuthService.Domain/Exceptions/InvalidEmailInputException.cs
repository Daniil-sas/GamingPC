namespace AuthService.Domain.Exceptions
{
    public class InvalidEmailInputException : Exception
    {
        public InvalidEmailInputException() : base("Invalid email input") { }
    }
}
