using UsersManagerApi.Data.Dtos.UserDtos;

namespace UsersManagerApi.Models
{
    public class AuthCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public GetUserDto User { get; set; }
        public string Token { get; set; }
    }
}
