using CodeFirst.Entities;
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
                    select new { n = book.Title, a =  book.AuthorSurname };
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
                List<Book> books = app.Books.Where(a=>a.AuthorSurname == surname).ToList();
                foreach (var item in books)
                {
                    Console.WriteLine(item.Title + " " + item.AuthorSurname);
                }
            }

        }
    }
}
