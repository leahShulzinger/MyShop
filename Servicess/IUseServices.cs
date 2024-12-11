using Entities;

namespace Servicess
{
    public interface IUseServices
    {
        int Chakepassword(string password);
        Task<User> Get(int id);
        Task<User> Login(string email, string password);
        Task<User> Post(User user);
        Task<User> Put(int id, User userToUpdate);
    }
}