using System;
using System.Collections.Generic;
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
                List<Entities.Book> books = app.Books.ToList();
                foreach (var item in books)
                {
                    string a = item.AuthorSurname != null ? item.AuthorSurname : "не задано";
                    Console.WriteLine($"Название книги: {item.Title}\tЖанр: {item.Genre}\tАвтор: {a}\tГод издания: {item.YearOfIssue}\tId читателя: {item.UserId}");
                }
            }
        }

        public void AddBook()
        {
            Entities.Book book = new Entities.Book();
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
                Entities.Book newBook = app.Books.FirstOrDefault();
                app.Books.Add(book);
                app.SaveChanges();
            }
        }

        public void DeleteBookById(int id)
        {
            using (AppContext app = new AppContext())
            {
                Entities.Book? book = app.Books.Where(x => x.Id == id).FirstOrDefault();
                app.Books.Remove(book);
                app.SaveChanges();
            }
        }
        public void BookDataChangeById(int Id)
        {
            using (AppContext app = new AppContext())
            {
                //создается сущность (Entities)
                Entities.Book bookData = app.Books.Where(i => i.Id == Id).FirstOrDefault();
                Console.Write("Введите отредактированную Год издания: ");
                bookData.YearOfIssue = Convert.ToInt32(Console.ReadLine());
                app.Books.Update(bookData);
                //FrameWork при вызове SaveChanges() сам определит, что изменилось и произведет нужный SQLзапрос
                app.SaveChanges();
            }
        }
    }
}
