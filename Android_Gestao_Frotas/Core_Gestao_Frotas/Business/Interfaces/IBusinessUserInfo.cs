using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessUserInfo
    {
        Task<User> GetUser(int id);

        Task<bool> CreateUser(User user);

        Task<bool> UpdateUser(User user);

        Task<List<Profile>> GetProfiles();

        Task<string> GetDefaultPassword();
    }
}
