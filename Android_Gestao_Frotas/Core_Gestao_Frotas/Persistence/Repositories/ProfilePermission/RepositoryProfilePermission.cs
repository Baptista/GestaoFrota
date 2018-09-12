using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission
{
    public class RepositoryProfilePermission : BaseRepository, IRepositoryProfilePermission
    {
        public async Task<int> Insert(ProfilePermissionPersistence profilePermissionPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(profilePermissionPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<ProfilePermissionPersistence> profilesPermissionPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(profilesPermissionPersistence);
            return result;
        }

        public async Task<int> Delete(ProfilePermissionPersistence profilePermissionPersistence)
        {
            var result = await DBConnection.DeleteAsync(profilePermissionPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<ProfilePermissionPersistence> profilesPermissionPersistence)
        {
            var result = await DBConnection.DeleteAsync(profilesPermissionPersistence);
            return result;
        }

        public async Task<int> Update(ProfilePermissionPersistence profilePermissionPersistence)
        {
            var result = await DBConnection.UpdateAsync(profilePermissionPersistence);
            return result;
        }

        public async Task<int> Update(List<ProfilePermissionPersistence> profilesPermissionPersistence)
        {
            var result = await DBConnection.UpdateAsync(profilesPermissionPersistence);
            return result;
        }

        public async Task<List<ProfilePermissionPersistence>> GetAllPermissionsOfProfile(int profileId)
        {
            var profilePermissions = await DBConnection.Table<ProfilePermissionPersistence>()
                                                    .Where(entry => entry.IdProfile == profileId)
                                                    .ToListAsync();
            return profilePermissions;
        }
    }
}
