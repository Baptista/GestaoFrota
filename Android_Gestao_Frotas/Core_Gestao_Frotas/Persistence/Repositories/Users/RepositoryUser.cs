using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Users
{
    class RepositoryUser: BaseRepository, IRepositoryUser
    {

        public async Task<int> Insert(User User)
        {
            var persistence = MapperUser.ToPersistence(User);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<User> Users)
        {
            var persistences = MapperUser.ToPersistence(Users);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(User User)
        {
            var persistence = MapperUser.ToPersistence(User);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<User> Users)
        {
            var persistences = MapperUser.ToPersistence(Users);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(User User)
        {
            var persistence = MapperUser.ToPersistence(User);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<User> Users)
        {
            var persistences = MapperUser.ToPersistence(Users);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<User> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<UserPersistence>(conf => conf.Id == id);
            var User = MapperUser.ToModel(persistence);
            return User;
        }

        public async Task<List<User>> GetAll()
        {
            var persistences = await DBConnection.Table<UserPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Users = MapperUser.ToModel(persistences);
            return Users;
        }

        public async Task<int> Insert(UserPersistence UserPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(UserPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<UserPersistence> UsersPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(UsersPersistence);
            return result;
        }

        public async Task<int> Delete(UserPersistence UserPersistence)
        {
            var result = await DBConnection.DeleteAsync(UserPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<UserPersistence> UsersPersistence)
        {
            var result = await DBConnection.DeleteAsync(UsersPersistence);
            return result;
        }

        public async Task<int> Update(UserPersistence UserPersistence)
        {
            var result = await DBConnection.UpdateAsync(UserPersistence);
            return result;
        }

        public async Task<int> Update(List<UserPersistence> UsersPersistence)
        {
            var result = await DBConnection.UpdateAsync(UsersPersistence);
            return result;
        }

        public async Task<List<User>> GetActiveUsers()
        {
            var persistence = await DBConnection.Table<UserPersistence>().Where(user => user.Active == 1).ToListAsync();
            var users = MapperUser.ToModel(persistence);
            return users;
        }
    }
}
