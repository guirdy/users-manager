using AutoMapper;
using UsersManagerApi.Data.Dtos.User;
using UsersManagerApi.Model;

namespace UsersManagerApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UpdateUserDto>();
        }
    }
} 
