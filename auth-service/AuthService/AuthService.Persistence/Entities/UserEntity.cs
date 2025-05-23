namespace AuthService.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public int Points { get; set; }
    }
}
