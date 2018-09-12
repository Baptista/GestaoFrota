using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class VehicleHistory : BaseModel
    {
        public int Id { get; set; }

        public RequestHistory RequestHistory { get; set; }

        public DateTime Date { get; set; }

        public decimal Kms { get; set; }

        public VehicleHistory()
        {

        }
    }
}
