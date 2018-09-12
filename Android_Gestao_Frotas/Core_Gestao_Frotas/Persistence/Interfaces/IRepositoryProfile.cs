using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryProfile
    {

        Task<int> Insert(Profile Profile);

        Task<int> InsertAll(List<Profile> Profiles);

        Task<int> Delete(Profile Profile);

        Task<int> DeleteAll(List<Profile> Profiles);

        Task<int> Update(Profile Profile);

        Task<int> Update(List<Profile> Profiles);

        Task<int> Insert(ProfilePersistence ProfilePersistence);

        Task<int> InsertAll(List<ProfilePersistence> ProfilesPersistence);

        Task<int> Delete(ProfilePersistence ProfilePersistence);

        Task<int> DeleteAll(List<ProfilePersistence> ProfilesPersistence);

        Task<int> Update(ProfilePersistence ProfilePersistence);

        Task<int> Update(List<ProfilePersistence> ProfilesPersistence);

        Task<Profile> Get(int id);

        Task<List<Profile>> GetAll();

    }
}
