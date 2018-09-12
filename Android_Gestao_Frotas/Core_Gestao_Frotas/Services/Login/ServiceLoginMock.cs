using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Login
{
    public class ServiceLoginMock : IServiceLogin
    {
        public Task<string> GetProfile(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExecuteLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginUtilizador(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
