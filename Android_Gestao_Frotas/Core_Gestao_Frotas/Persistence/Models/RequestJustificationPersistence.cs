using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class RequestJustificationPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdJustificacaoPedidoMarcacao")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdTipoJustificacaoPedido")]
        public int IdRequestJustificationType { get; set; }

        [JsonProperty(PropertyName = "IdPedidoMarcacao")]
        public int IdRequest { get; set; }

        [JsonProperty(PropertyName = "IdPedidoMarcacaoConflito")]
        public int IdRequestConflict { get; set; }

        [MaxLength(4000), JsonProperty(PropertyName = "Justificacao")]
        public string Justification { get; set; }

        public RequestJustificationPersistence()
        {

        }
    }
}
