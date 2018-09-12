using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class RequestJustification : BaseModel
    {
        public int Id { get; set; }

        public Request Request { get; set; }

        public RequestJustificationType RequestJustificationType { get; set; }

        //public RequestConflict RequestConflict { get; set; }

        public string Justification { get; set; }

        public RequestJustification()
        {

        }
    }
}
