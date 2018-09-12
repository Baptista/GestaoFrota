using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class ConfigurationPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdConfiguracao")]
        public int Id { get; set; }

        [MaxLength(100), JsonProperty(PropertyName = "Parametro")]
        public string Parameter { get; set; }

        [MaxLength(255), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        public ConfigurationPersistence()
        {

        }
    }
}
