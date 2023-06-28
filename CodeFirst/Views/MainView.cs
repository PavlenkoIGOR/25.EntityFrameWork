using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using CodeFirst.Repositories;

namespace CodeFirst.Views
{
    public enum Choice
    {
        show,
        add,
        update,
        delete,
        sba,
        sort,
        exit
    }
    internal class MainView
    {

        private BookView _bookView;
        private UserView _userView;
        public MainView(BookView bookView, UserView userView) 
        {
            _bookView = bookView;
            _userView = userView;
        }
        

        public void MainViewMethod()
        {
            string choice = string.Empty;
            do
            {
                Console.Write("Работать с Книгами или Пользователями (1 или 2. 'exit' - выход)?: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _bookView.WorkWithBooks();
                        break;
                    case "2":
                        _userView.WorkWithUsers();
                        break;
                }
            } while (choice != nameof(Choice.exit));
        }
    }
}
