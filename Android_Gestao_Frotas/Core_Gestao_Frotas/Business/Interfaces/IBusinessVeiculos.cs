using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessVeiculos
    {
        Task<IEnumerable<Brand>> GetBrands(bool usePersistence = false);
        Task<IEnumerable<Model>> GetModels(bool usePersistence = false);
        Task<IEnumerable<Typology>> GetTypologies(bool usePersistence = false);
        Task<IEnumerable<Vehicle>> GetVehicles(bool usePersistence = false);
        Task<IEnumerable<Fuel>> GetFuels(bool usePersistence = false);
        Task<bool> InsertMarca(Brand brand);
        Task<bool> InsertModel(Model model);
        Task<bool> InsertTypology(Typology typology);
        Task<bool> UpdateMarca(Brand brand);
        Task<bool> UpdateModel(Model model);
        Task<bool> UpdateTypology(Typology typology);
        Task<bool> ChangeMarcaState(Brand brand);
        Task<bool> ChangeModelState(Model model);
        Task<bool> ChangeTypologyState(Typology typology);
        Task<bool> ChangeVehicleState(Vehicle vehicle);
        Task<bool> UpdateAllModel(Brand brand);
    }
}
