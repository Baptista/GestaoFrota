using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Configurations;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicleDocuments;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicles;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Permissions;
using Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Dashboard;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Login;
using Core_Gestao_Frotas.Services.Splash;
using Core_Gestao_Frotas.Services.Users;
using Core_Gestao_Frotas.Services.Vehicles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Login
{
    public class BusinessLogin : BaseBusiness, IBusinessLogin
    {
        public async Task<bool> Login(string username, string password)
        {
            IServiceLogin servicelogin = new ServiceLogin();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            IRepositoryPermission repositoryPermission = new RepositoryPermission();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

            var userJson = await servicelogin.ExecuteLogin(username, password);
            if (!string.IsNullOrEmpty(userJson))
            {
                try
                {
                    var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(userJson);
                    var user = MapperUser.ToModel(userPersistence[0]);

                    if (user.Profile.IsIncomplete)
                    {
                        user.Profile = await repositoryProfile.Get(user.Profile.Id);
                        if (user.Profile.Permissions == null)
                            user.Profile.Permissions = new Dictionary<Permission, bool>();

                        var profilePermissions = await repositoryProfilePermission.GetAllPermissionsOfProfile(user.Profile.Id);
                        foreach (var profilePermission in profilePermissions)
                        {
                            var permission = await repositoryPermission.Get(profilePermission.IdPermission);
                            if (permission != null)
                                user.Profile.Permissions.Add(permission, profilePermission.Active == 1 ? true : false);
                        }
                    }

                    AllYouCanGet.CurrentUser = user;

                    return true;
                }
                catch(Exception attemptLoginException)
                {
                    Debug.WriteLine(attemptLoginException.StackTrace);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckIfPasswordIsDefault()
        {
            IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();

            var defaultPasswordConfiguration = await repositoryConfiguration.GetDefaultPassword();
            if (AllYouCanGet.CurrentUser.Password.Equals(defaultPasswordConfiguration.Description))
                return true;

            return false;
        }

        public async Task<User> LoginUtilizador(string id)
        {
            IServiceLogin servicelogin = new ServiceLogin();
            var result = await servicelogin.LoginUtilizador(id);
            var user = JsonConvert.DeserializeObject<List<UserPersistence>>(result);
            var usermodel = MapperUser.ToModel(user[0]);
            usermodel.Profile = await GetProfile(user[0].IdProfile.ToString());
            _user = usermodel;
            return usermodel;
        }

        public async Task<Profile> GetProfile(string id)
        {
            IServiceLogin servicelogin = new ServiceLogin();
            var result = await servicelogin.GetProfile(id);
            var profile = JsonConvert.DeserializeObject<List<ProfilePersistence>>(result);
            return MapperProfile.ToModel(profile[0]);
        }

        public async Task<bool> LoadUsers()
        {
            try
            {
                IServiceLogin serviceLogin = new ServiceLogin();
                IRepositoryUser repositoryUser = new RepositoryUser();

                var usersJson = await serviceLogin.GetUsers();

                var UsersPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(usersJson);
                
                var usersResult = await repositoryUser.InsertAll(UsersPersistence);

                return true;
            }
            catch(Exception exceptionLoadVehicles)
            {
                Debug.WriteLine(exceptionLoadVehicles.StackTrace);
                return false;
            }
        }
    }
}
