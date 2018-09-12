using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryVehicle
    {
        Task<int> Insert(Vehicle Vehicle);

        Task<int> InsertAll(List<Vehicle> Vehicles);

        Task<int> Delete(Vehicle Vehicle);

        Task<int> DeleteAll(List<Vehicle> Vehicles);

        Task<int> Update(Vehicle Vehicle);

        Task<int> Update(List<Vehicle> Vehicles);

        Task<int> Insert(VehiclePersistence VehiclePersistence);

        Task<int> InsertAll(List<VehiclePersistence> VehiclesPersistence);

        Task<int> Delete(VehiclePersistence VehiclePersistence);

        Task<int> DeleteAll(List<VehiclePersistence> VehiclesPersistence);

        Task<int> Update(VehiclePersistence VehiclePersistence);

        Task<int> Update(List<VehiclePersistence> VehiclesPersistence);

        Task<Vehicle> Get(int id);

        Task<List<Vehicle>> GetAll();

        Task<List<Vehicle>> GetAllActiveVehicles();

        Task<List<Vehicle>> GetAllVehiclesForUser(int userId, bool onlyActive = true);
    }
}
