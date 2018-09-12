using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class RequestState : BaseModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public RequestState()
        {

        }

        public override string ToString()
        {
            return Description;
        }

    }
}
