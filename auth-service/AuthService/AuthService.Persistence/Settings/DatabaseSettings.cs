namespace AuthService.Persistence.Settings
{
    public class DatabaseSettings
    {
        public string Host { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;

        public string ConnectionString
            => $"Host={Host};Port={Port};Database={Name};Username={User};Password={Password}";
    }
}
