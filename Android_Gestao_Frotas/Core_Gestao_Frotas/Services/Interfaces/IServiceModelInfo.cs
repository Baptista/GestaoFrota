using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceModelInfo
    {
        Task<string> ChangeModelState(Model model);

        Task<string> NewModel(Model model);

        Task<string> UpdateModel(Model model);
    }
}
