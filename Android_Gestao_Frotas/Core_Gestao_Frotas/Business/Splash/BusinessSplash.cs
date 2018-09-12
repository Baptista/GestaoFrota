using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Configurations;
using Core_Gestao_Frotas.Persistence.Repositories.Permissions;
using Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Splash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Splash
{
    public class BusinessSplash : BaseBusiness, IBusinessSplash
    {
        public async Task<bool> LoadAppSettingsAndConfigurations()
        {
            try
            {
                IServiceSplash serviceSplash = new ServiceSplash();
                IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();
                IRepositoryProfile repositoryProfile = new RepositoryProfile();
                IRepositoryPermission repositoryPermission = new RepositoryPermission();
                IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

                var configurationsResponse = await serviceSplash.GetConfigutations();
                var profilesResponse = await serviceSplash.GetProfiles();
                var permissionsResponse = await serviceSplash.GetPermissions();
                var profilePermissionResponse = await serviceSplash.GetProfilePermissions();

                var configurations = JsonConvert.DeserializeObject<List<ConfigurationPersistence>>(configurationsResponse);
                var profiles = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profilesResponse);
                var permissions = JsonConvert.DeserializeObject<List<PermissionPersistence>>(permissionsResponse);
                var profilePermissions = JsonConvert.DeserializeObject<List<ProfilePermissionPersistence>>(profilePermissionResponse);

                var configResult = await repositoryConfiguration.InsertAll(configurations);
                var profileResult = await repositoryProfile.InsertAll(profiles);
                var permissionResult = await repositoryPermission.InsertAll(permissions);
                var profilePermissionResult = await repositoryProfilePermission.InsertAll(profilePermissions);

                return true;
            }
            catch (Exception loadSettingsException)
            {
                Debug.WriteLine(loadSettingsException.StackTrace);
                return false;
            }
        }
    }
}
