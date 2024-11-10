using Entities;
using Reposetories;
using System.Text.Json;
using Zxcvbn;
//...

namespace Servicess
{
    public class UseServices : IUseServices
    {
        IUserReposetory reposetory;
        public UseServices(IUserReposetory reposetory)
        {
            this.reposetory = reposetory;
        }
        public User Get(int id)
        {
            return reposetory.Get(id);
        }

        public User Post(User user)
        {
            int check = Chakepassword(user.Password);
            if (check >= 3)
                return reposetory.Post(user);
            return null;

        }

        public User Login(string email, string password)
        {

            int check = Chakepassword(password);
            if (check >= 3)
                return reposetory.Login(email, password);
            return null;

        }

        public User Put(int id, User userToUpdate)
        {
            int check = Chakepassword(userToUpdate.Password);
            if (check >= 3)
                return reposetory.Put(id, userToUpdate);
            return null;
        }
        public int Chakepassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;

        }
    }
}
