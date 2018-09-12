using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceUsers
    {
        Task<string> GetUsers();

        Task<string> GetUser(int id);

        Task<string> GetProfiles();

        Task<string> ResetUserPassword(int id);

        Task<string> ChangeUserState(int id, bool state);

        Task<string> CreateUser(User user);

        Task<string> UpdateUser(User user);

    }
}
