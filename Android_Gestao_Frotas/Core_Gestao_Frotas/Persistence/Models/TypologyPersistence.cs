using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class TypologyPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdTipologia")]
        public int Id { get; set; }

        [MaxLength(255), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public Byte Active { get; set; }

        public TypologyPersistence()
        {

        }
    }
}
