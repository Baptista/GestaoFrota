using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class VehiclePersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdVeiculo")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdModelo")]
        public int IdModel { get; set; }

        [JsonProperty(PropertyName = "IdTipologia")]
        public int IdTypology { get; set; }

        [JsonProperty(PropertyName = "IdUtilizador")]
        public string IdUser { get; set; }

        [MaxLength(8), JsonProperty(PropertyName = "Matricula")]
        public string LicensePlate { get; set; }

        [JsonProperty(PropertyName = "Disponivel")]
        public Byte Available { get; set; }

        [JsonProperty(PropertyName = "KmsIniciais")]
        public float StartKms { get; set; }

        [JsonProperty(PropertyName = "KmsContrato")]
        public float ContractKms { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public Byte Active { get; set; }

        public VehiclePersistence()
        {

        }
    }
}
