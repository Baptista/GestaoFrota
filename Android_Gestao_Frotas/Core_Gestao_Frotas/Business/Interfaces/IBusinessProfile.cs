using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessProfile
    {

        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int id);
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Profile> AddProfile(Profile profile);
        Task<bool> AddProfilePermission(int idprofile, int idpermissao, int ativo);
        Task<IEnumerable<Profile>> GetProfilesNew();
        Task<bool> UpdateProfile(Profile profile);
        Task<int> CheckUserStatusProfile(Profile profile);
        Task<bool> UpdateProfileState(Profile profile);
        Task<bool> DeletePermissions(Profile profile);
    }
}
