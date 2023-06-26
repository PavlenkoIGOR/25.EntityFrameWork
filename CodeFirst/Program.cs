using CodeFirst.Entities;
using CodeFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Repositories;

namespace CodeFirst
{
    public enum Choice
    {
        show,
        add,
        update,
        delete,
        exit
    }

    public class Program
    {
        static void Main(string[] args)
        {
            UserRepository<User> userRepository = new UserRepository<User>();
            BookRepository bookRepository = new BookRepository();


            string choice = string.Empty;
            do
            {
                Console.WriteLine("Чё надо?\n'show': показать все данные;\n'add': добавить пользователя;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
                Console.Write("Так, чё надо?\nВведите команду: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case nameof(Choice.show):
                        //userRepository.SelectAllUsers();
                        bookRepository.SelectAllBooks();
                        break;
                    case nameof(Choice.delete):
                        Console.Write("Введите Id пользователя для удаления: ");
                        //userRepository.DeleteUserById(Convert.ToInt32(Console.ReadLine()));
                        bookRepository.DeleteBookById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.update):
                        Console.Write("Введите Id пользователя для редактирования: ");
                        //userRepository.UserDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        bookRepository.BookDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.add):
                        //userRepository.AddUser();
                        bookRepository.AddBook();
                        break;
                }
            } while (choice != nameof(Choice.exit));
        }
    }
}