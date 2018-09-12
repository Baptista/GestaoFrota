using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Permissions;
using Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.ProfileService;
using Core_Gestao_Frotas.Services.Splash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Profiles
{
    public class BusinessProfile : BaseBusiness, IBusinessProfile
    {
        public async Task<Profile> AddProfile(Profile profile)
        {
            IServiceProfile serviceProfile = new ServiceProfile();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();

            var profileJson = await serviceProfile.AddProfile(profile);

            var profilePersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profileJson);

            var result = await repositoryProfile.Insert(profilePersistence[0]);

            var result2 = MapperProfile.ToModel(profilePersistence[0]);

            return result2;
        }

        public async Task<bool> AddProfilePermission(int idprofile, int idpermissao, int ativo)
        {
            IServiceProfile serviceProfile = new ServiceProfile();

            var profileJson = await serviceProfile.AddProfilePermission(idprofile,idpermissao, ativo);

            return true;
        }

        public async Task<int> CheckUserStatusProfile(Profile profile)
        {
            IServiceProfile serviceProfile = new ServiceProfile();

            var status = await serviceProfile.CheckUserStatusProfile(profile);
            var statusreal = 0;
            var result = int.TryParse(status, out statusreal);
            return statusreal;
        }

        public async Task<bool> DeletePermissions(Profile profile)
        {
            IServiceProfile serviceProfile = new ServiceProfile();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

            List<KeyValuePair<Permission, bool>> _permissions = new List<KeyValuePair<Permission, bool>>();
             _permissions = profile.Permissions.ToList();

            var result = await serviceProfile.DeletePermissions(profile);

            var result3 = await repositoryProfilePermission.GetAllPermissionsOfProfile(profile.Id);

            for (int i = 0; i < result3.Count; i++)
            {
                var result4 = await repositoryProfilePermission.Delete(result3[i]);
            }

            var result2 = await GetProfilesNew();

            return result;
        }

        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            IRepositoryPermission repositoryPermission = new RepositoryPermission();
            var Permissions = await repositoryPermission.GetAll();
            return Permissions;
        }

        public async Task<Profile> GetProfile(int id)
        {
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            IRepositoryPermission repositoryPermission = new RepositoryPermission();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

            var profile = await repositoryProfile.Get(id);


                if (profile.Permissions == null)
                {
                    profile.Permissions = new Dictionary<Permission, bool>();
                }

                var profilePermissions = await repositoryProfilePermission.GetAllPermissionsOfProfile(profile.Id);
                foreach (var profilePermission in profilePermissions)
                {
                    var permission = await repositoryPermission.Get(profilePermission.IdPermission);
                    if (permission != null)
                        profile.Permissions.Add(permission, profilePermission.Active == 1 ? true : false);
                }

            return profile;
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            IRepositoryPermission repositoryPermission = new RepositoryPermission();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

            var profiles = await repositoryProfile.GetAll();

            for (int i = 0; i < profiles.Count; i++)
            {
                if (profiles[i].Permissions == null)
                {
                    profiles[i].Permissions = new Dictionary<Permission, bool>();
                }

                var profilePermissions = await repositoryProfilePermission.GetAllPermissionsOfProfile(profiles[i].Id);
                foreach (var profilePermission in profilePermissions)
                {
                    var permission = await repositoryPermission.Get(profilePermission.IdPermission);
                    if (permission != null)
                        profiles[i].Permissions.Add(permission, profilePermission.Active == 1 ? true : false);
                }

            }

            return profiles;
        }

        public async Task<IEnumerable<Profile>> GetProfilesNew()
        {
            IServiceSplash serviceSplash = new ServiceSplash();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            IRepositoryPermission repositoryPermission = new RepositoryPermission();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();

            var profilesResponse = await serviceSplash.GetProfiles();
            var permissionsResponse = await serviceSplash.GetPermissions();
            var profilePermissionResponse = await serviceSplash.GetProfilePermissions();

            var profiles = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profilesResponse);
            var permissions = JsonConvert.DeserializeObject<List<PermissionPersistence>>(permissionsResponse);
            var profilePermissions = JsonConvert.DeserializeObject<List<ProfilePermissionPersistence>>(profilePermissionResponse);

            var profileResult = await repositoryProfile.InsertAll(profiles);
            var permissionResult = await repositoryPermission.InsertAll(permissions);
            var profilePermissionResult = await repositoryProfilePermission.InsertAll(profilePermissions);

            var listaprofiles = await GetProfiles();

            return listaprofiles;

        }

        public async Task<bool> UpdateProfile(Profile profile)
        {
            IServiceProfile serviceProfile = new ServiceProfile();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();

            var profileJson = await serviceProfile.UpdateProfile(profile);

            var profilePersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(profileJson);

            var result = await repositoryProfile.Update(profilePersistence[0]);

            return true;
        }

        public async Task<bool> UpdateProfileState(Profile profile)
        {
            IServiceProfile serviceProfile = new ServiceProfile();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();

            var updateprofile = await serviceProfile.ChangeProfileState(profile);

            var profilePersistence = JsonConvert.DeserializeObject<List<ProfilePersistence>>(updateprofile);
            var result = await repositoryProfile.Update(profilePersistence[0]);

            return result == 1 ? true : false;
        }
    }
}
