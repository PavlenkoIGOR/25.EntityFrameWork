using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    public class AppContext : DbContext //определяет контекст данных, используемый для взаимодействия с базой данных, и
                                        //является базовым классом для создаваемого контекста вашего приложения.
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; } //представляет набор объектов типа T, которые хранятся в определенной таблице БД. В моём случае Users.

        public DbSet<Book> Books { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //переопределенный метод для настройки подключения к БД.
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-G5TER77\\SQLEXPRESS; Database = ForEntityFW;TrustServerCertificate=True; Trusted_Connection=True; Encrypt=false");
        }
    }
}
