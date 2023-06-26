using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }    
        public DateTime? YearOfIssue { get; set; }

        //внешний ключ:
        public int BookId { get; set; } //обратить внимание на синтаксис названия поля

        //навигационное свойство - ссылка на пользователя
        public User? User { get; set; }
    }
}
