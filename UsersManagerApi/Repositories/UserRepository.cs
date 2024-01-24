using UsersManagerApi.Data;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;
using UsersManagerApi.Utils;

namespace UsersManagerApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? GetUserById(Guid userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user;
        }

        public User? GetUserByEmail(string email)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Email == email);
            return user;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
