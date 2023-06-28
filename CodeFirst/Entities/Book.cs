using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Book
    {
        //первичный ключ
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string AuthorSurname { get; set; }    
        public int YearOfIssue { get; set; }
        
        //внешний ключ
        public int? UserId { get; set; } //обратить внимание на синтаксис названия поля

        //навигационное свойство - ссылка на пользователя
        //[ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
