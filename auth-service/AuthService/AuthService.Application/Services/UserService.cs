using AuthService.Application.DTOs;
using AuthService.Application.Interfaces.Auth;
using AuthService.Domain.Exceptions;
using AuthService.Domain.Interfaces.Repositories;
using AuthService.Domain.Models;
using System.Text.RegularExpressions;

namespace AuthService.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRefreshTokenRepositories _refreshTokenRepositories;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IRefreshTokenRepositories refreshTokenRepositories)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _refreshTokenRepositories = refreshTokenRepositories;
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
            var emailRegex = new Regex("[\\w\\.]+@([\\w-]+\\.)+[\\w-]{2,4}", RegexOptions.IgnoreCase);

            if (!emailRegex.IsMatch(email))
            {
                throw new InvalidEmailInputException();
            }

            var authUser = await _userRepository.GetByEmail(email);

            if (authUser != null)
            {
                throw new UserAlreadyExistsException();
            }

            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword, login, 0);

            await _userRepository.Add(user);
        }

        /// <summary>
        /// Проверка существования пользователя, создание JWT токена для хранения его в cookie
        /// И создание с сохранением Refresh Token в Redis
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<JWTTokenResult> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email) ??
                throw new UserNotFoundException();

            if (!_passwordHasher.Verify(password, user.PasswordHash))
            {
                throw new UserNotFoundException();
            }

            var token = _jwtProvider.GenerateToken(user);

            var refreshToken = _jwtProvider.GenerateRefreshToken();

            await _refreshTokenRepositories.StoreTokenAsync(user.Id.ToString(), refreshToken.Token, refreshToken.ExpiriesIn);

            return new(token.Token, refreshToken.Token);
        }
    }
}
