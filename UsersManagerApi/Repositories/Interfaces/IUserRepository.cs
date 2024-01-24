using UsersManagerApi.Model;

namespace UsersManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(Guid userId);
        User GetUserByEmail(string email);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(Guid userId);
    }
}
