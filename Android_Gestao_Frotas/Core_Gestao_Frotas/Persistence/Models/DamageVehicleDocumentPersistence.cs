using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class DamageVehicleDocumentPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdDanosVeiculoComprovativo")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdDanosVeiculo")]
        public int IdDamageVehicle { get; set; }

        [JsonProperty(PropertyName = "Documento")]
        public byte[] Document { get; set; }

        [MaxLength(50), JsonProperty(PropertyName = "FormatoDocumento")]
        public string DocumentFormat { get; set; }

        [MaxLength(4000), JsonProperty(PropertyName = "NomeDocumento")]
        public string DocumentName { get; set; }

        [JsonProperty(PropertyName = "Data")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public byte Active { get; set; }

        public DamageVehicleDocumentPersistence()
        {

        }
    }
}
