using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Splash
{
    public class BusinessSplashMock : IBusinessSplash
    {
        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadAppSettingsAndConfigurations()
        {
            throw new NotImplementedException();
        }
    }
}
