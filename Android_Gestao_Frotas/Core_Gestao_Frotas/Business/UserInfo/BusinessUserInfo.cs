using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Configurations;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.UserInfo
{
    public class BusinessUserInfo : BaseBusiness, IBusinessUserInfo
    {
        public async Task<bool> CreateUser(User user)
        {
            IServiceUsers serviceUsers = new ServiceUsers();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var serviceResponse = await serviceUsers.CreateUser(user);

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(serviceResponse);
            var result = await repositoryUser.Insert(userPersistence[0]);

            return result == 1 ? true : false;
        }

        public User GetCurrentUser()
        {
            return _user;
        }

        public async Task<string> GetDefaultPassword()
        {
            IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();

            var configuration = await repositoryConfiguration.GetDefaultPassword();

            return configuration.Description;
        }

        public async  Task<List<Profile>> GetProfiles()
        {
            IServiceUsers serviceUsers = new ServiceUsers();

            var profilesJson = await serviceUsers.GetProfiles();

            var profilesPersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profilesJson);

            var profiles = MapperProfile.ToModel(profilesPersistence);

            return profiles;
        }

        public async Task<User> GetUser(int id)
        {
            IServiceUsers serviceUsers = new ServiceUsers();

            var userJson = await serviceUsers.GetUser(id);
            var profileJson = await serviceUsers.GetProfiles();

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(userJson);
            var profilePersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profileJson);

            var user = MapperUser.ToModel(userPersistence[0]);
            var profiles = MapperProfile.ToModel(profilePersistence);

            if (user.Profile.IsIncomplete)
                user.Profile = profiles.FirstOrDefault(profile => { return profile.Id == user.Profile.Id; });

            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            IServiceUsers serviceUsers = new ServiceUsers();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var serviceResponse = await serviceUsers.UpdateUser(user);

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(serviceResponse);
            var result = await repositoryUser.Update(userPersistence[0]);

            return result == 1 ? true : false;
        }
    }
}
