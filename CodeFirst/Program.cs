using CodeFirst.Entities;
using CodeFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Repositories;

namespace CodeFirst
{
    public enum Choice
    {
        show,
        update,
        delete,
        exit
    }

    public class Program
    {
        static void Main(string[] args)
        {
            /*
            using (AppContext app = new AppContext())
            {
                
                var user1 = new User { Name = "Arthur", Role = "Admin" };
                var user2 = new User { Name = "Klim", Role = "User" };
                                
                //добавим пользователей в таблицу Users, обращаясь к полю Users нашего контекста db, и сохраним изменения:
                app.Users.Add(user1);
                app.Users.Add(user2);

                //добавление книг в таблицу Books, обращаясь к полю Books нашего контекста db:
                Book book1 = new Book() { title = "Black Holes and Revelations", author = "MUSE", yearOfIssue = new DateTime(2006, 06, 03) };
                Book book2 = new Book() { title = "Пикник на обочине", author = "Борис и Аркадий Стругацкие", yearOfIssue = new DateTime(1972, 10, 28) };
                app.Books.Add(book1);
                app.Books.Add(book2);
                

                //добавление данных в существующую запись:
                var user1 = app.Users.First();
                user1.Email = "postBox1@mail.com";

                app.SaveChanges(); //в указанной базе данных создастся таблица Users (т.к. такое имя указано в DbSet<User> Users)
            }
            */

            UserRepository<User> userRepository = new UserRepository<User>();
            string choice = string.Empty;
            do
            {
                Console.WriteLine("Чё надо?\n'show': показать все данные;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
                Console.Write("Так чё надо?\nВведите команду: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case nameof(Choice.show):
                        userRepository.SelectAllUsers();
                        break;
                    case nameof(Choice.delete):
                        Console.Write("Введите Id пользователя для удаления: ");
                        userRepository.DeleteUserById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.update):
                        Console.Write("Введите Id пользователя для редактирования: ");
                        userRepository.UserDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        break;
                }
            } while (choice != nameof(Choice.exit));
            userRepository.SelectAllUsers();

            Console.ReadLine();
        }
    }
}