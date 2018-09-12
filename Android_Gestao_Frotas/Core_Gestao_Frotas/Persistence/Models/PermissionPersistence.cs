using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Models
{
    public class PermissionPersistence : BasePersistence
    {
        [PrimaryKey, Indexed, JsonProperty(PropertyName = "IdPermissao")]
        public int Id { get; set; }

        [MaxLength(4000), JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        public PermissionPersistence()
        {

        }
    }
}
