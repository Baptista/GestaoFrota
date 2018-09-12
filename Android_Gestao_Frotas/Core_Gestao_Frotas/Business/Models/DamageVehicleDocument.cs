using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class DamageVehicleDocument : BaseModel
    {
        public int Id { get; set; }

        public DamageVehicle DamageVehicle { get; set; }

        public byte[] Document { get; set; }

        public string DocumentFormat { get; set; }

        public string DocumentName { get; set; }

        public DateTime Date { get; set; }

        public bool Active { get; set; }

        public DamageVehicleDocument()
        {

        }
    }
}
