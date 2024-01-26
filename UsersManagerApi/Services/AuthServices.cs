using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Models;
using UsersManagerApi.Repositories.Interfaces;
using UsersManagerApi.Utils;

namespace UsersManagerApi.Services
{
    public class AuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly PwdHash _pwdHash = new PwdHash();
        private readonly TokenService _tokenService;

        public AuthServices(IUserRepository userRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public ActionResult<AuthResponse>? Authenticate(AuthCredentials credentials)
        {
            User? user = _userRepository.GetUserByEmail(credentials.Email);

            if (user == null)
                return null;

            bool isPasswordValid = _pwdHash.VerifyPassword(credentials.Password, user.Password, user.PwdSalt);

            if (!isPasswordValid)
                return null;

            var token = _tokenService.GenerateToken(user);

            user.Password = "";

            return new AuthResponse
            {
                User = _mapper.Map<GetUserDto>(user),
                Token = token
            };
        }
    }
}
