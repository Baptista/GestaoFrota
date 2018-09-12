using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceNewPassword
    {
        Task<string> ChangeUserPassword(User user, string newPassword);
        Task<string> ChangeDefaultPassword(string newPassword);
    }
}
