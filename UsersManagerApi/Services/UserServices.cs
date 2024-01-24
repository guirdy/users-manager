using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public void UpdateUser(
            GetUserDto user,
            JsonPatchDocument<UpdateUserDto> patch,
            ModelStateDictionary modelState)
        {
            User originalUser = _userRepository.GetUserById(user.Id);
            UpdateUserDto userToUpdate = _mapper.Map<UpdateUserDto>(originalUser);

            patch.ApplyTo(userToUpdate, modelState);

            if (!modelState.IsValid)
            {
                throw new Exception("Ocorreu um erro ao atualizar o usuário.");
            }

            _mapper.Map(userToUpdate, originalUser);
            _userRepository.UpdateUser();
        }

        public void DeleteUser(Guid userId)
        {
            User? user = _userRepository.GetUserById(userId);
            _userRepository.DeleteUser(user);
        }
    }
}
