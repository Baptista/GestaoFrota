using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Profiles
{
    public class RepositoryProfile: BaseRepository, IRepositoryProfile
    {

        public async Task<int> Insert(Profile Profile)
        {
            var persistence = MapperProfile.ToPersistence(Profile);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Profile> Profiles)
        {
            var persistences = MapperProfile.ToPersistence(Profiles);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Profile Profile)
        {
            var persistence = MapperProfile.ToPersistence(Profile);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Profile> Profiles)
        {
            var persistences = MapperProfile.ToPersistence(Profiles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Profile Profile)
        {
            var persistence = MapperProfile.ToPersistence(Profile);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Profile> Profiles)
        {
            var persistences = MapperProfile.ToPersistence(Profiles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Profile> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<ProfilePersistence>(conf => conf.Id == id);
            var Profile = MapperProfile.ToModel(persistence);
            return Profile;
        }

        public async Task<List<Profile>> GetAll()
        {
            var persistences = await DBConnection.Table<ProfilePersistence>().OrderBy(m => m.Id).ToListAsync();
            var Profiles = MapperProfile.ToModel(persistences);
            return Profiles;
        }

        public async Task<int> Insert(ProfilePersistence ProfilePersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(ProfilePersistence);
            return result;
        }

        public async Task<int> InsertAll(List<ProfilePersistence> ProfilesPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(ProfilesPersistence);
            return result;
        }

        public async Task<int> Delete(ProfilePersistence ProfilePersistence)
        {
            var result = await DBConnection.DeleteAsync(ProfilePersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<ProfilePersistence> ProfilesPersistence)
        {
            var result = await DBConnection.DeleteAsync(ProfilesPersistence);
            return result;
        }

        public async Task<int> Update(ProfilePersistence ProfilePersistence)
        {
            var result = await DBConnection.UpdateAsync(ProfilePersistence);
            return result;
        }

        public async Task<int> Update(List<ProfilePersistence> ProfilesPersistence)
        {
            var result = await DBConnection.UpdateAsync(ProfilesPersistence);
            return result;
        }

    }
}
