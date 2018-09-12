using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class VehicleDeliveryPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdVeiculoEntrega")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdPedidoMarcacaoHistorico")]
        public int IdRequestHistory { get; set; }

        [JsonProperty(PropertyName = "Data")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "Kms")]
        public decimal Kms { get; set; }

        public VehicleDeliveryPersistence()
        {

        }
    }
}
