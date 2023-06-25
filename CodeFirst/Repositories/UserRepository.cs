using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace CodeFirst.Repositories
{
    internal class UserRepository<User>
    {
        public void SelectAllUsers()
        {
            using (AppContext app = new AppContext())
            {
                List <Entities.User> users = app.Users.ToList();
                foreach (var item in users)
                {
                    string e = item.Email != null ? item.Email : "не задано";
                    Console.WriteLine($"Id: {item.Id}\tName: {item.Name}\tEmail: {e}\tRole: {item.Role}");
                }
            }
        }

        public void DeleteUserById(int id)
        {
            using (AppContext app = new AppContext()) 
            {
                Entities.User? user = app.Users.Where(x => x.Id == id).FirstOrDefault();
                app.Users.Remove(user);
                app.SaveChanges();
            }
        }
    }
}
