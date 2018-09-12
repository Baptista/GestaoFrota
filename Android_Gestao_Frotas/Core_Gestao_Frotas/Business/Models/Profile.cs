using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class Profile : BaseModel
    {
        public int Id { get; set; }
        
        public string Description { get; set; }

        public bool Active { get; set; }

        public Dictionary<Permission, bool> Permissions { get; set; }

        public Profile()
        {

        }

        public override string ToString()
        {
            return Description;
        }

        public bool IsActive(string permissionDescription)
        {
            if (Permissions.Any())
            {
                var permission = Permissions.FirstOrDefault(keyValuePair => { return keyValuePair.Key.Description.Equals(permissionDescription); });
                if (permission.Key != null)
                    return permission.Value;
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}
