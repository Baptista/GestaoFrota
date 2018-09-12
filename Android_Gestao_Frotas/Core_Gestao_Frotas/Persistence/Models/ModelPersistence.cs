using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class ModelPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdModelo")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdMarca")]
        public int IdBrand { get; set; }

        [JsonProperty(PropertyName = "IdCombustivel")]
        public int IdFuel { get; set; }

        [MaxLength(255), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public Byte Active { get; set; }

        public ModelPersistence()
        {

        }
    }
}
