namespace AuthService.Infrastructure.Settings
{
    public class RedisSetting
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string ConnectionString =>
            $"{Host}:{Port},password={Password},abortConnect=false";
    }
}
