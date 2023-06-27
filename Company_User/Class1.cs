using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_User
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Внешний ключ
        public int CompanyId { get; set; }
        // Навигационное свойство
        public Company Company { get; set; }
    }
}
