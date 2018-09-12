using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperPermission
    {

        public static PermissionPersistence ToPersistence(Permission Permission)
        {
            var PermissionPersistence = new PermissionPersistence()
            {
                Id = Permission.Id,
                Description = Permission.Description
            };

            return PermissionPersistence;
        }

        public static List<PermissionPersistence> ToPersistence(List<Permission> Permissions)
        {
            var PermissionsPersistence = new List<PermissionPersistence>();

            foreach (var Permission in Permissions)
            {
                PermissionsPersistence.Add(new PermissionPersistence()
                {
                    Id = Permission.Id,
                    Description = Permission.Description
                });
            }

            return PermissionsPersistence;
        }

        public static Permission ToModel(PermissionPersistence PermissionPersistence)
        {
            var Permission = new Permission()
            {
                Id = PermissionPersistence.Id,
                Description = PermissionPersistence.Description
            };

            return Permission;
        }

        public static List<Permission> ToModel(List<PermissionPersistence> PermissionsPersistence)
        {
            var Permissions = new List<Permission>();

            foreach (var PermissionPersistence in PermissionsPersistence)
            {
                Permissions.Add(new Permission()
                {
                    Id = PermissionPersistence.Id,
                    Description = PermissionPersistence.Description
                });
            }

            return Permissions;
        }

    }
}