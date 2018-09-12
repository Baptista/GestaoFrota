using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Permissions
{
    class RepositoryPermission: BaseRepository, IRepositoryPermission
    {

        public async Task<int> Insert(Permission Permission)
        {
            var persistence = MapperPermission.ToPersistence(Permission);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Permission> Permissions)
        {
            var persistences = MapperPermission.ToPersistence(Permissions);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Permission Permission)
        {
            var persistence = MapperPermission.ToPersistence(Permission);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Permission> Permissions)
        {
            var persistences = MapperPermission.ToPersistence(Permissions);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Permission Permission)
        {
            var persistence = MapperPermission.ToPersistence(Permission);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Permission> Permissions)
        {
            var persistences = MapperPermission.ToPersistence(Permissions);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Permission> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<PermissionPersistence>(conf => conf.Id == id);
            var Permission = MapperPermission.ToModel(persistence);
            return Permission;
        }

        public async Task<List<Permission>> GetAll()
        {
            var persistences = await DBConnection.Table<PermissionPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Permissions = MapperPermission.ToModel(persistences);
            return Permissions;
        }

        public async Task<int> Insert(PermissionPersistence PermissionPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(PermissionPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<PermissionPersistence> PermissionsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(PermissionsPersistence);
            return result;
        }

        public async Task<int> Delete(PermissionPersistence PermissionPersistence)
        {
            var result = await DBConnection.DeleteAsync(PermissionPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<PermissionPersistence> PermissionsPersistence)
        {
            var result = await DBConnection.DeleteAsync(PermissionsPersistence);
            return result;
        }

        public async Task<int> Update(PermissionPersistence PermissionPersistence)
        {
            var result = await DBConnection.UpdateAsync(PermissionPersistence);
            return result;
        }

        public async Task<int> Update(List<PermissionPersistence> PermissionsPersistence)
        {
            var result = await DBConnection.UpdateAsync(PermissionsPersistence);
            return result;
        }

    }
}
