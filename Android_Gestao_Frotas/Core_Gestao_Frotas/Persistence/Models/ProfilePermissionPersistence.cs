using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class ProfilePermissionPersistence : BasePersistence
    {

        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdPerfilPermissao")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdPerfil")]
        public int IdProfile { get; set; }

        [JsonProperty(PropertyName = "IdPermissao")]
        public int IdPermission { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public byte Active { get; set; }

        public ProfilePermissionPersistence()
        {

        }
    }
}
