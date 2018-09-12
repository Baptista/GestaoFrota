using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryPermission
    {

        Task<int> Insert(Permission Permission);

        Task<int> InsertAll(List<Permission> Permissions);

        Task<int> Delete(Permission Permission);

        Task<int> DeleteAll(List<Permission> Permissions);

        Task<int> Update(Permission Permission);

        Task<int> Update(List<Permission> Permissions);

        Task<int> Insert(PermissionPersistence PermissionPersistence);

        Task<int> InsertAll(List<PermissionPersistence> PermissionsPersistence);

        Task<int> Delete(PermissionPersistence PermissionPersistence);

        Task<int> DeleteAll(List<PermissionPersistence> PermissionsPersistence);

        Task<int> Update(PermissionPersistence PermissionPersistence);

        Task<int> Update(List<PermissionPersistence> PermissionsPersistence);

        Task<Permission> Get(int id);

        Task<List<Permission>> GetAll();

    }
}
