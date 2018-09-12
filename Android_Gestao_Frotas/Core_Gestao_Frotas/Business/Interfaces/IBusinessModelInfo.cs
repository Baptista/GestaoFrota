using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessModelInfo
    {
        Task<Model> GetModelAsync(int id);

        Task<List<Brand>> GetAllActiveBrandsAsync();

        Task<List<Fuel>> GetAllActiveFuelsAsync();

        Task<bool> NewModelAsync(Model model);

        Task<bool> UpdateModelAsync(Model model, bool changeState = false);

        Task<bool> ChangeModelState(Model model);
    }
}
