using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class FuelPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdCombustivel")]
        public int Id { get; set; }

        [MaxLength(50), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        public FuelPersistence()
        {

        }
    }
}
