using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Splash
{
    public class ServiceSplashMock : IServiceSplash
    {
        public Task<string> GetConfigutations()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPermissions()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetProfilePermissions()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetProfiles()
        {
            throw new NotImplementedException();
        }
    }
}
