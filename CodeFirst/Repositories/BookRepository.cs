using System;
using System.Collections.Generic;
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
                    string a = item.Author != null ? item.Author : "не задано";
                    Console.WriteLine($"Название книги: {item.Title}\tЖанр: {item.Genre}\tАвтор: {a}\tГод издания: {item.YearOfIssue}");
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

            Console.WriteLine("Введите Автора новой книги: ");
            book.Author = Console.ReadLine();

            Console.WriteLine("Введите Дату издания книги (День.Месяц.Год): ");
            book.YearOfIssue = Convert.ToDateTime(Console.ReadLine());
            
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
                Console.Write("Введите отредактированную Жанр издания (День.Месяц.Год): ");
                bookData.Genre = Console.ReadLine();//Convert.ToDateTime(Console.ReadLine());

                //FrameWork при вызове SaveChanges() сам определит, что изменилось и произведет нужный SQLзапрос
                app.SaveChanges();
            }
        }
    }
}
