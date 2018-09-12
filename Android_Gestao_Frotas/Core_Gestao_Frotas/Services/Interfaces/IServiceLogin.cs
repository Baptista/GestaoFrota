using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceLogin
    {
        Task<string> ExecuteLogin(string username, string password);

        Task<string> LoginUtilizador(string id);

        Task<string> GetProfile(string id);

        Task<string> GetUsers();
    }
}
