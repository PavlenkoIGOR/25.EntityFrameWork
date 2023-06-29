using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repositories
{
    public class BookRepository
    {
        public void SelectAllBooks()
        {
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.ToList();
                foreach (var item in books)
                {
                    string a = item.AuthorSurname != null ? item.AuthorSurname : "не задано";
                    Console.WriteLine($"Название книги: {item.Title}\tЖанр: {item.Genre}\tАвтор: {a}\tГод издания: {item.YearOfIssue}\tId читателя: {item.UserId}");
                }
            }
        }

        public void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Введите Название новой книги: ");
            book.Title = Console.ReadLine();

            Console.WriteLine("Введите Жанр новой книги: ");
            book.Genre = Console.ReadLine();

            Console.WriteLine("Введите Фамилию автора новой книги: ");
            book.AuthorSurname = Console.ReadLine();

            Console.WriteLine("Введите Год издания книги: ");
            book.YearOfIssue = Convert.ToInt32(Console.ReadLine());

            using (AppContext app = new AppContext())
            {
                Book newBook = app.Books.FirstOrDefault();
                app.Books.Add(book);
                app.SaveChanges();
            }
        }

        public void DeleteBookById(int id)
        {
            using (AppContext app = new AppContext())
            {
                Book? book = app.Books.Where(x => x.Id == id).FirstOrDefault();
                app.Books.Remove(book);
                app.SaveChanges();
            }
        }
        public void BookDataChangeById(int Id)
        {
            using (AppContext app = new AppContext())
            {
                //создается сущность (Entities)
                Book bookData = app.Books.Where(i => i.Id == Id).FirstOrDefault();
                Console.Write("Введите отредактированный Год издания: ");
                bookData.YearOfIssue = Convert.ToInt32(Console.ReadLine());
                app.Books.Update(bookData);
                //FrameWork при вызове SaveChanges() сам определит, что изменилось и произведет нужный SQLзапрос
                app.SaveChanges();
            }
        }
        public void SortBooksByTitile8()
        {
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.ToList();
                var sort =
                    from book in books
                    orderby book.Title.ToUpper()
                    select new { n = book.Title, a = book.AuthorSurname };
                foreach (var item in sort)
                {
                    Console.WriteLine($"Название: {item.n}\tАвтор: {item.a}");
                }
            }
        }

        public void ShowBooksFromAuthor()
        {
            Console.Write("Введите фамилию автора: ");
            string surname = Console.ReadLine();
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.Where(a => a.AuthorSurname.ToUpper() == surname).ToList();
                foreach (var item in books)
                {
                    Console.WriteLine(item.Title + " " + item.AuthorSurname);
                }
            }

        }

        public void GetByGenre()
        {
            Console.WriteLine("Введите интересующий жанр: ");
            string genre = Console.ReadLine();
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.Where(b => b.Genre.ToUpper() == genre).ToList();
                foreach (var item in books)
                {
                    Console.WriteLine(item.Genre + " " + item.Title + " " + item.AuthorSurname);
                }
            }
        }
        public void CountBooksByGenre()
        {
            Console.WriteLine("Введите интересующий жанр для подсчёта количества книг: ");
            string genre = Console.ReadLine();
            uint count = default;
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.Where(g => g.Genre.ToUpper() == genre).ToList();
                Console.WriteLine($"Количество книг интересующего жанра \"{genre}\": {books.Count()}");
            }
        }

        public void BooksFromYearInterval()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Поиск по временному интервалу");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите временной интервал (годОт - годДо): ");
            string yearInteval = Console.ReadLine();

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = yearInteval.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int[] years = new int[words.Length];
            for (int i = 0; i < years.Length; i++)
            {
                years[i] = Convert.ToInt32(words[i]);
            }

            using (AppContext app = new AppContext())
            {
                //List<Book> books = app.Books.Where(y => y.YearOfIssue >= years[0] & y.YearOfIssue <= years[1]).ToList();
                List<Book> books = app.Books.ToList();
                var yb = from book in books
                         where book.YearOfIssue >= years[0] & book.YearOfIssue <= years[1]
                         select book;
                foreach (var item in yb)
                {
                    Console.WriteLine($"книга: {item.AuthorSurname} автор: {item.AuthorSurname} год публикации: {item.YearOfIssue}");
                }
            }
        }

        public void IsOnHandsByUser()
        {
            Console.Write("Введите userId: ");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ввведите bookId: ");
            int bookid = Convert.ToInt32(Console.ReadLine());
            using (AppContext app = new AppContext())
            {
                var search = app.Users.Where(uid => uid.Id == userid && uid.Books.Contains(app.Books.Where(b => b.Id == bookid).First()) );
                Console.WriteLine($"Id книги: {search.Any()} Id пользователя: {userid}");
            }
        }
    }
}
