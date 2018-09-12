using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Vehicles
{
    class RepositoryVehicle: BaseRepository, IRepositoryVehicle
    {

        public async Task<int> Insert(Vehicle Vehicle)
        {
            var persistence = MapperVehicle.ToPersistence(Vehicle);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Vehicle> Vehicles)
        {
            var persistences = MapperVehicle.ToPersistence(Vehicles);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Vehicle Vehicle)
        {
            var persistence = MapperVehicle.ToPersistence(Vehicle);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Vehicle> Vehicles)
        {
            var persistences = MapperVehicle.ToPersistence(Vehicles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Vehicle Vehicle)
        {
            var persistence = MapperVehicle.ToPersistence(Vehicle);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Vehicle> Vehicles)
        {
            var persistences = MapperVehicle.ToPersistence(Vehicles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Vehicle> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<VehiclePersistence>(conf => conf.Id == id);
            var Vehicle = MapperVehicle.ToModel(persistence);
            return Vehicle;
        }

        public async Task<List<Vehicle>> GetAll()
        {
            var persistences = await DBConnection.Table<VehiclePersistence>().OrderBy(m => m.Id).ToListAsync();
            var Vehicles = MapperVehicle.ToModel(persistences);
            return Vehicles;
        }

        public async Task<int> Insert(VehiclePersistence VehiclePersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(VehiclePersistence);
            return result;
        }

        public async Task<int> InsertAll(List<VehiclePersistence> VehiclesPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(VehiclesPersistence);
            return result;
        }

        public async Task<int> Delete(VehiclePersistence VehiclePersistence)
        {
            var result = await DBConnection.DeleteAsync(VehiclePersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<VehiclePersistence> VehiclesPersistence)
        {
            var result = await DBConnection.DeleteAsync(VehiclesPersistence);
            return result;
        }

        public async Task<int> Update(VehiclePersistence VehiclePersistence)
        {
            var result = await DBConnection.UpdateAsync(VehiclePersistence);
            return result;
        }

        public async Task<int> Update(List<VehiclePersistence> VehiclesPersistence)
        {
            var result = await DBConnection.UpdateAsync(VehiclesPersistence);
            return result;
        }

        public async Task<List<Vehicle>> GetAllActiveVehicles()
        {
            var persistences = await DBConnection.Table<VehiclePersistence>().Where(v => v.Active == 1).ToListAsync();
            var vehicles = MapperVehicle.ToModel(persistences);
            return vehicles;
        }

        public async Task<List<Vehicle>> GetAllVehiclesForUser(int userId, bool onlyActive = true)
        {
            var user = userId == User.Null ? "NULL" : userId.ToString();

            var usersPersistence = new List<VehiclePersistence>();
            if (onlyActive)
            {
                usersPersistence = await DBConnection.Table<VehiclePersistence>()
                                                .Where(v => v.IdUser == user && v.Active == 1).ToListAsync();
            }
            else
            {
               usersPersistence  = await DBConnection.Table<VehiclePersistence>()
                                                .Where(v => v.IdUser == user).ToListAsync();
            }

            var vehicles = MapperVehicle.ToModel(usersPersistence);

            return vehicles;
        }
    }
}
