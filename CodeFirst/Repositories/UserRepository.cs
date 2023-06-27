using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace CodeFirst.Repositories
{
    internal class UserRepository<U> where U : class //<...> - в дальнейшем надо переделать под универсальный класс
    {
        public void SelectAllUsers()
        {
            using (AppContext app = new AppContext())
            {
                List <Entities.User> users = app.Users.ToList();
                foreach (var item in users)
                {
                    string e = item.Email != null ? item.Email : "не задано";
                    Console.WriteLine($"Id: {item.Id}\tИмя: {item.Name}\tEmail: {e}\tАдрес: {item.Address}\tКниги на руках: ???");
                }
            }
        }

        public void AddUser()
        {
            Entities.User user = new Entities.User();
            Console.WriteLine("Введите Имя нового пользователя: ");
            user.Name = Console.ReadLine();

            Console.WriteLine("Введите Email нового пользователя: ");
            user.Email = Console.ReadLine();

            Console.WriteLine("Введите Адрес нового пользователя: ");
            user.Address = Console.ReadLine();

            using (AppContext app = new AppContext())
            {
                Entities.User newUser = app.Users.FirstOrDefault();
                app.Users.Add(user);
                app.SaveChanges();
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
        public void UserDataChangeById(int Id)
        {
            using (AppContext app = new AppContext())
            {
                //создается сущность (Entities)
                Entities.User userData = app.Users.Where(i => i.Id == Id).FirstOrDefault();
                Console.Write("Введите новое имя пользователя: ");
                userData.Name = Console.ReadLine();

                //FrameWork при вызове SaveChanges() сам определит, что изменилось и произведет нужный SQLзапрос
                app.SaveChanges();
            }
        }
    }
}
