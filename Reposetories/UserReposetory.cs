using Entities;
using System.Text.Json;
namespace Reposetories
{

    public class UserReposetory : IUserReposetory
    {
        MyShop328120357Context myShop;



        public UserReposetory(MyShop328120357Context myShop)
        {
            this.myShop = myShop;
        }

        List<User> users = new();
        public async Task<User> Get(int id)
        {
            User user = await myShop.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Post(User user)
        {
            await myShop.Users.AddAsync(user);
            await myShop.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string email, string password)
        {
          

            User user = await myShop.Users.FindAsync(email);
            return user;


        }

        public async Task<User> Put(int id, User userToUpdate)
        {
            myShop.Users.Update(userToUpdate);
            await myShop.SaveChangesAsync();
            return userToUpdate;

        }
    }


}
