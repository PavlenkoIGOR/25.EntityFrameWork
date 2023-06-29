using CodeFirst.Entities;
using CodeFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Views;


namespace CodeFirst
{


    public class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            BookRepository bookRepository = new BookRepository();
            
            #region
            using (AppContext app = new AppContext())
            {
                
                app.Database.EnsureDeleted();
                app.Database.EnsureCreated();

                User user1 = new User { Name = "user1", Email = "user1@mail.com", Address = "user1 street", Books = new List<Book> () };
                User user2 = new User { Name = "user2", Email = "user2@mail.com", Address = "user2 street", Books = new List<Book>() };
                User user3 = new User { Name = "user3", Email = "user3@mail.com", Address = "user3 street", Books = new List<Book>() };
                User user4 = new User { Name = "user4", Email = "user4@mail.com", Address = "user4 street", Books = new List<Book>() };
                User user5 = new User { Name = "user5", Email = "user5@mail.com", Address = "user5 street", Books = new List<Book>() };
                User user6 = new User { Name = "user6", Email = "user6@mail.com", Address = "user6 street" };
                app.Users.AddRange(user1, user2, user3, user4, user5, user6);

                Book book1 = new Book { Title = "20000 лье под водой", Genre = "Научная фантастика", AuthorSurname = "Верн", YearOfIssue = 1870, User = user1 };
                Book book2 = new Book { Title = "Ведьмак", Genre = "Фэнтези", AuthorSurname = "Сапковский", YearOfIssue = 1993, User = user5 };
                Book book3 = new Book { Title = "Горе от ума", Genre = "Комедия", AuthorSurname = "Грибоедов", YearOfIssue = 1825, User = user1 };
                Book book4 = new Book { Title = "Пикник на обочине", Genre = "Научная фантастика", AuthorSurname = "Стругацкие", YearOfIssue = 1972, User = user5 };
                Book book5 = new Book { Title = "Метро 2033", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfIssue = 2005, User = user2 };
                Book book6 = new Book { Title = "Метро 2034", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfIssue = 2009, User = user2 };
                Book book7 = new Book { Title = "Метро 2035", Genre = "Постапокалиптический роман", AuthorSurname = "Глуховский", YearOfIssue = 2015, User = user4 };
                Book book8 = new Book { Title = "Война и мир", Genre = "Роман", AuthorSurname = "Толстой", YearOfIssue = 1869, User = user4 };
                Book book9 = new Book { Title = "Золотой телёнок", Genre = "Сатира", AuthorSurname = "Ильф и Петров", YearOfIssue = 1931, User = user4 };
                Book book10 = new Book { Title = "Автостопом по галактике", Genre = "Фэнтези", AuthorSurname = "Дуглас", YearOfIssue = 1979, User = user3 };
                Book book11 = new Book { Title = "Какое-то", Genre = "Какоё-то", AuthorSurname = "Кто-то", YearOfIssue = 0001 };
                app.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11);
                

                
                app.SaveChanges();
            };
            #endregion
            
            BookView bookView = new BookView(bookRepository);
            UserView userView = new UserView(userRepository);
            MainView mainView = new MainView(bookView, userView);
            mainView.MainViewMethod();
        }
    }
}