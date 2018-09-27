using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Users
{
    public class BusinessUsers : BaseBusiness, IBusinessUsers
    {

        public static List<User> ListUsers;

        public async Task<IEnumerable<User>> GetUsers()
        {
            IServiceUsers serviceUsers = new ServiceUsers();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();

            var usersJson = await serviceUsers.GetUsers();
            var profilesJson = await serviceUsers.GetProfiles();

            var usersweb = JsonConvert.DeserializeObject<List<WebUser>>(usersJson);
            var profilesweb = JsonConvert.DeserializeObject<List<WebProfile>>(profilesJson);

            var usersPersistence = MapperWeb.WebUserListToPersistence(usersweb);
            var profilesPersistence = MapperWeb.WebProfileToPersistence(profilesweb);

            //var usersPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(usersJson);
            //var profilesPersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profilesJson);

            var usersResult = repositoryUser.InsertAll(usersPersistence);
            var profileResult = repositoryProfile.InsertAll(profilesPersistence);

            var users = MapperUser.ToModel(usersPersistence);
            var profiles = MapperProfile.ToModel(profilesPersistence);
            foreach (var user in users)
                if (user.Profile.IsIncomplete)
                    user.Profile = profiles.First(profile => { return profile.Id == user.Profile.Id; });

            return users;
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetUserPassword(User user)
        {
            IServiceUsers serviceUsers = new ServiceUsers();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var userJson = await serviceUsers.ResetUserPassword(user.Id);

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(userJson);
            var updateResult = await repositoryUser.Update(userPersistence[0]);

            return true;
        }

        public async Task<bool> ChangeUserState(int id, bool state)
        {
            IServiceUsers serviceUsers = new ServiceUsers();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var userJson = await serviceUsers.ChangeUserState(id, state);

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(userJson);

            var userResult = await repositoryUser.Update(userPersistence[0]);

            return true;
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            return _user;
        }

        public async Task<bool> CheckUserProfileStatus(User user)
        {
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            var result = await repositoryProfile.Get(user.Profile.Id);

            return result.Active;

        }
    }
}
