namespace AuthService.Domain.Models
{
    public class User
    {
        private User(Guid id, string userName, string email, string passwordHash, string login)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Login = login;
        }
        private User() { }
        public Guid Id { get; }

        public string UserName { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string PasswordHash { get; } = string.Empty;

        public string Login { get; } = string.Empty;


        public static User Create(Guid id, string userName, string email, string passwordHash, string login)
        {
            return new User(id, userName, email, passwordHash, login);
        }
    }
}
