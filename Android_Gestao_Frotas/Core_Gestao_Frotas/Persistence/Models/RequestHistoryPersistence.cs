using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class RequestHistoryPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdPedidoMarcacaoHistorico")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdPedidoMarcacao")]
        public int IdRequest { get; set; }

        [JsonProperty(PropertyName = "IdEstadoPedidoMarcacao")]
        public int IdRequestState { get; set; }

        [JsonProperty(PropertyName = "IdVeiculo")]
        public int IdVehicle { get; set; }

        [JsonProperty(PropertyName = "IdUtilizador")]
        public int IdUser { get; set; }

        [JsonProperty(PropertyName = "DataInicio")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "DataFim")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public byte Active { get; set; }

        public RequestHistoryPersistence()
        {

        }
    }
}
