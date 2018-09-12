using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }

        public Profile Profile { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{Name} ({Username})";
        }

    }
}
