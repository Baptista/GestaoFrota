using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessNewPassword
    {
        Task<bool> TryChangePassword(string newPassword);

        Task<bool> TryChangePasswordDefault(string newPassword);

        Task<bool> IsCurrentPassword(string password);

        Task<bool> ValidateNewPassword(string newPassword, string confirmNewPassword);

        Task<string> GetDefaultPassword();
    }
}
