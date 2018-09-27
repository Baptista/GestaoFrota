using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
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

                var ConfigutationsJson = await serviceSplash.GetConfigutations();
                var webConfigutations = JsonConvert.DeserializeObject<List<WebConfiguration>>(ConfigutationsJson);
                var ConfigutationsPersistence = MapperWeb.WebConfigurationToPersistence(webConfigutations);

                var profilesJson = await serviceSplash.GetProfiles();
                var webprofiles = JsonConvert.DeserializeObject<List<WebProfile>>(profilesJson);
                var profilesPersistence = MapperWeb.WebProfileToPersistence(webprofiles);

                var PermissionsJson = await serviceSplash.GetPermissions();
                var webPermissions = JsonConvert.DeserializeObject<List<WebPermission>>(PermissionsJson);
                var PermissionsPersistence = MapperWeb.WebPermissionToPersistence(webPermissions);

                var ProfilePermissionsJson = await serviceSplash.GetProfilePermissions();
                var webProfilePermissions = JsonConvert.DeserializeObject<List<WebProfilePermission>>(ProfilePermissionsJson);
                var ProfilePermissionsPersistence = MapperWeb.WebProfilePermissionToPersistence(webProfilePermissions);

                //var configurations = JsonConvert.DeserializeObject<List<ConfigurationPersistence>>(configurationsResponse);
                //var profiles = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profilesResponse);
                //var permissions = JsonConvert.DeserializeObject<List<PermissionPersistence>>(permissionsResponse);
                //var profilePermissions = JsonConvert.DeserializeObject<List<ProfilePermissionPersistence>>(profilePermissionResponse);

                var configResult = await repositoryConfiguration.InsertAll(ConfigutationsPersistence);
                var profileResult = await repositoryProfile.InsertAll(profilesPersistence);
                var permissionResult = await repositoryPermission.InsertAll(PermissionsPersistence);
                var profilePermissionResult = await repositoryProfilePermission.InsertAll(ProfilePermissionsPersistence);

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
