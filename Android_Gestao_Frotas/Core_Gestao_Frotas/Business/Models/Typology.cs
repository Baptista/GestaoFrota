using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class Typology : BaseModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public Typology()
        {

        }

        public override string ToString()
        {
            return Description;
        }

    }
}
