using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class DamageVehicle : BaseModel
    {
        public int Id { get; set; }

        public RequestHistory RequestHistory { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DamageVehicle()
        {

        }
    }
}
