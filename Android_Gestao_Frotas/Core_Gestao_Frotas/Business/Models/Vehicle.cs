using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class Vehicle : BaseModel
    {
        public int Id { get; set; }

        public Model Model { get; set; }

        public Typology Typology { get; set; }

        public User User { get; set; }

        public string LicensePlate { get; set; }

        public float StartKms { get; set; }

        public float ContractKms { get; set; }

        public bool Available { get; set; }

        public bool Active { get; set; }

        public Vehicle()
        {

        }

        public override string ToString()
        {
            var brand = "MARCA";
            var model = "MODELO";

            if (Model != null && !Model.IsIncomplete && Model.Brand != null && !Model.Brand.IsIncomplete)
            {
                brand = Model.Brand.Description;
                model = Model.Description;
            }

            return $"{brand} - {model} - {LicensePlate}";
        }

        public string IdToString()
        {
            var brand = "MARCA";

            if (Model != null && !Model.IsIncomplete && Model.Brand != null && !Model.Brand.IsIncomplete)
                brand = Model.Brand.Description;

            return $"{brand} - {LicensePlate}";
        }
    }
}
