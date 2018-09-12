using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class UserPersistence : BasePersistence
    {        
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdUtilizador")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdPerfil")]
        public int IdProfile { get; set; }

        [MaxLength(50), JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }

        [MaxLength(20), JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [MaxLength(255), JsonProperty(PropertyName = "Nome")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Ativo")]
        public Byte Active { get; set; }

        public UserPersistence()
        {

        }
    }
}
