using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Users
{
    public class ServiceUsersMock : BaseService, IServiceUsers
    {
        public Task<string> ChangeUserState(int id, bool state)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<string> IServiceUsers.CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<string> IServiceUsers.ResetUserPassword(int id)
        {
            throw new NotImplementedException();
        }
    }
}
