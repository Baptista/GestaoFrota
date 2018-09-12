using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    interface IServiceVehicle
    {
        Task<String> GetBrands();
        Task<String> GetModels();
        Task<String> GetTypologys();
        Task<String> GetVehicles();
        Task<String> GetFuels();
        Task<String> InsertBrand(Brand brand);
        Task<String> InsertModel(Model model);
        Task<String> InsertTypology(Typology typology);
        Task<String> UpdateBrand(Brand brand);
        Task<String> UpdateModel(Model model);
        Task<String> UpdateTypology(Typology typology);
        Task<String> ChangeBrandState(Brand brand);
        Task<String> ChangeModelState(Model model);
        Task<String> ChangeTypologyState(Typology typology);
        Task<String> UpdateAllModel(Brand brand);
        Task<String> ChangeVehicleState(Vehicle vehicle);
    }
}
