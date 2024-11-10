using Entities;

namespace Servicess
{
    public interface IUserServicess
    {
        int CheckPassword(string password);
        User Get(int id);
        User Login(string email, string password);
        User Post(User user);
        User Put(int id, User userToUpdate);
    }
}