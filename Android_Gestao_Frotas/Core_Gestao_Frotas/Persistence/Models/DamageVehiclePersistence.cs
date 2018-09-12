using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class DamageVehiclePersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdDanosVeiculo")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdVeiculo")]
        public int IdVehicle { get; set; }

        [JsonProperty(PropertyName = "IdPedidoMarcacaoHistorico")]
        public string IdRequestHistory { get; set; }

        [JsonProperty(PropertyName = "Data")]
        public DateTime Date { get; set; }

        [MaxLength(4000), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public byte Active { get; set; }

        public DamageVehiclePersistence()
        {

        }
    }
}
