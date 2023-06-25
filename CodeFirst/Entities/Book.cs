using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Book
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }    
        public DateTime? yearOfIssue { get; set; }
    }
}
