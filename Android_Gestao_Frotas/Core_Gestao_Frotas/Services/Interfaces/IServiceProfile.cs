using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
   public interface IServiceProfile
    {
        Task<string> AddProfile(Profile profile);
        Task<string> AddProfilePermission(int idprofile, int idpermissao, int ativo);
        Task<string> UpdateProfile(Profile profile);
        Task<string> ChangeProfileState(Profile profile);
        Task<string> CheckUserStatusProfile(Profile profile);
        Task<bool> DeletePermissions(Profile profile);
    }
}
