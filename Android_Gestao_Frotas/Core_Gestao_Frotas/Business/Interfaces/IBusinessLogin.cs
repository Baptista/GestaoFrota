using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessLogin
    {
        Task<bool> Login(string username, string password);

        Task<bool> CheckIfPasswordIsDefault();

        Task<User> LoginUtilizador(string id);

        Task<bool> LoadUsers();
    }
}
