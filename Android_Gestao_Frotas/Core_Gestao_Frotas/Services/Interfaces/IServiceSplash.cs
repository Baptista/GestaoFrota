using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceSplash
    {
        Task<string> GetConfigutations();

        Task<string> GetProfiles();

        Task<string> GetPermissions();

        Task<string> GetProfilePermissions();
    }
}
