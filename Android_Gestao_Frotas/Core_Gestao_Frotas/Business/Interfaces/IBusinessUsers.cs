using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessUsers
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<IEnumerable<Profile>> GetProfiles();

        Task<bool> ResetUserPassword(User user);

        Task<bool> ChangeUserState(int id, bool state);

        Task<bool> CheckUserProfileStatus(User user);

        Task<bool> UpdateUser(User user);
    }
}
