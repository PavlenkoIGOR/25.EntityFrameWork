using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_User;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    public class AppContext : DbContext //определяет контекст данных, используемый для взаимодействия с базой данных, и
                                        //является базовым классом для создаваемого контекста вашего приложения.
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        public AppContext()
        {
            Database.EnsureCreated(); //создает базу данных в случае ее отсутствия при запуске приложения.
            //Database.EnsureDeleted(); //удаляет базу данных, если такавая существует
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //переопределенный метод для настройки подключения к БД.
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-G5TER77\\SQLEXPRESS; Database = ForEntityFW2;TrustServerCertificate=True; Trusted_Connection=True; Encrypt=false");
        }
    }
}
