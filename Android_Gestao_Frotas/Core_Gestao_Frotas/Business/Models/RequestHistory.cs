using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class RequestHistory : BaseModel
    {
        public int Id { get; set; }

        public Request Request { get; set; }
        
        public RequestState RequestState { get; set; }

        public Vehicle Vehicle { get; set; }

        public User User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public RequestHistory()
        {

        }
    }
}
