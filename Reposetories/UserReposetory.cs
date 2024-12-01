using Entities;
using System.Text.Json;


namespace Reposetories

{
    public class UserReposetory :  IUserReposetory
    {
        MyShop214935017Context myShop;
        public UserReposetory(MyShop214935017Context myShop)
        {
            this.myShop = myShop;
        }
        List<User> users = new();
        //public async Task<User> Get()
        //{
        //    await myShop.Users.GetAsyncEnumerator()
        //    return users;


        //}
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
            User user = await myShop.Users.FirstOrDeaultAsync(user=>user.password & user.Email);
            return user;

            //using (StreamReader reader = System.IO.File.OpenText(filePath))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.Email == email && user.Password == password)
            //            return user;
            //    }
            //}
            

        }
        public async Task<User> Put(int id, User userToUpdate)
        {
            myShop.Users.Update(userToUpdate);
            await myShop.SaveChangesAsync();
            return userToUpdate;

        }
    }
}
