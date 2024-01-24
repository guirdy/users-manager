using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;
using UsersManagerApi.Utils;

namespace UsersManagerApi.Services
{
    public class UserServices
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private PwdHash _pwdHash = new PwdHash();

        public UserServices(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _userRepository = repository;
        }

        public GetUserDto? GetUserById(Guid userId)
        {
            User? user = _userRepository.GetUserById(userId);
            return user == null ? null : _mapper.Map<GetUserDto>(user);
        }

        public GetUserDto? GetUserByEmail(string email)
        {
            User? user = _userRepository.GetUserByEmail(email);
            return user == null ? null : _mapper.Map<GetUserDto>(user);
        }

        public GetUserDto CreateUser(CreateUserDto userDto)
        {
            userDto.Password = _pwdHash.HashPassword(userDto.Password);
            User user = _mapper.Map<User>(userDto);
            User createdUser = _userRepository.CreateUser(user);

            return _mapper.Map<GetUserDto>(createdUser);
        }
    }
}
