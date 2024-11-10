using Entities;

namespace Reposetories
{
    public interface IUserReposetory
    {
        User Get(int id);
        User Login(string email, string password);
        User Post(User user);
        User Put(int id, User userToUpdate);
    }
}