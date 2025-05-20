using AuthService.Domain.Models;
using AuthService.Persistence.Entities;
using AutoMapper;

namespace AuthService.Persistence.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<UserEntity, User>();
        }
    }
}
