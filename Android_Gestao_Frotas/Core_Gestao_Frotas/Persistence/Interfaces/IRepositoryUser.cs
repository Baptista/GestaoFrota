using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    public interface IRepositoryUser
    {

        Task<int> Insert(User User);

        Task<int> InsertAll(List<User> Users);

        Task<int> Delete(User User);

        Task<int> DeleteAll(List<User> Users);

        Task<int> Update(User User);

        Task<int> Update(List<User> Users);

        Task<int> Insert(UserPersistence UserPersistence);

        Task<int> InsertAll(List<UserPersistence> UsersPersistence);

        Task<int> Delete(UserPersistence UserPersistence);

        Task<int> DeleteAll(List<UserPersistence> UsersPersistence);

        Task<int> Update(UserPersistence UserPersistence);

        Task<int> Update(List<UserPersistence> UsersPersistence);

        Task<User> Get(int id);

        Task<List<User>> GetAll();

        Task<List<User>> GetActiveUsers();
    }
}
