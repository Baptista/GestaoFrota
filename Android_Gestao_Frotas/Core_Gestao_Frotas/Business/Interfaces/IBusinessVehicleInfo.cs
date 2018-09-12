using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessVehicleInfo
    {
        Task<IEnumerable<Brand>> GetBrands();

        Task<IEnumerable<Model>> GetModels();

        Task<IEnumerable<Fuel>> GetFuels();

        Task<IEnumerable<Typology>> GetTypologies();

        Task<IEnumerable<User>> GetUsers();

        Task<Vehicle> GetVehicle(int id);

        Task<bool> ChangeVehicleState(Vehicle vehicle);

        Task<bool> NewVehicle(Vehicle vehicle);

        Task<bool> UpdateVehicle(Vehicle vehicle);
    }
}
