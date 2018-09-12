using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class RequestPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdPedidoMarcacao")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdUtilizador")]
        public int IdUser { get; set; }

        [JsonProperty(PropertyName = "Data")]
        public DateTime Date { get; set; }

        public RequestPersistence()
        {

        }
    }
}
