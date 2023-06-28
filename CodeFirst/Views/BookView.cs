using CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Views
{
    internal class BookView
    {
        private BookRepository _BookRepository;
        public BookView(BookRepository bookRepository) 
        {
            _BookRepository = bookRepository;
        }
        public void WorkWithBooks()
        {
            string choice = string.Empty;
            do
            {
                Console.WriteLine("Чё надо?" +
                    "\n'show': показать все данные;" +
                    "\n'add': добавить книгу;" +
                    "\n'update': изменить название;" +
                    "\n'sba': показать книги по автору;" +
                    "\n'sort': вывести отсортированные по названию книги;" +
                    "\n'delete': удалить по Id;" +
                    "\n'exit': выход\n");
                Console.Write("Так, чё надо?\nВведите команду: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case nameof(Choice.show):
                        _BookRepository.SelectAllBooks();
                        break;
                    case nameof(Choice.delete):
                        Console.Write("Введите Id книги для удаления: ");
                        _BookRepository.DeleteBookById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.update):
                        Console.Write("Введите Id книги для редактирования: ");
                        _BookRepository.BookDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.add):
                        _BookRepository.AddBook();
                        break;
                    case nameof(Choice.sort):
                        _BookRepository.SortBooksByTitile8();
                        break;
                    case nameof(Choice.sba):
                        _BookRepository.ShowBooksFromAuthor();
                        break;
                }
            } while (choice != nameof(Choice.exit));
        }
    }
}
