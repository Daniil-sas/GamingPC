using AuthService.Domain.Interfaces.Repositories;
using AuthService.Domain.Models;
using AuthService.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(AuthServiceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Login = user.Login
            };

            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
