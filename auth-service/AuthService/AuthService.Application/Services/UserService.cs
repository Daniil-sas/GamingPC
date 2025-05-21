using AuthService.Application.Interfaces.Auth;
using AuthService.Domain.Interfaces.Repositories;
using AuthService.Domain.Models;

namespace AuthService.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        /// <summary>
        /// Регистрация пользователя в БД
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="login"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task Register(string userName, string login, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword, login, 0);
            await Console.Out.WriteLineAsync("2");

            await _userRepository.Add(user);
        }

        /// <summary>
        /// Проверка существования пользователя и создание JWT токена ему
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
