using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys
{
    class RepositoryVehicleHistory: BaseRepository, IRepositoryVehicleHistory
    {

        public async Task<int> Insert(VehicleHistory VehicleHistory)
        {
            var persistence = MapperVehicleHistory.ToPersistence(VehicleHistory);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<VehicleHistory> VehicleHistorys)
        {
            var persistences = MapperVehicleHistory.ToPersistence(VehicleHistorys);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(VehicleHistory VehicleHistory)
        {
            var persistence = MapperVehicleHistory.ToPersistence(VehicleHistory);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<VehicleHistory> VehicleHistorys)
        {
            var persistences = MapperVehicleHistory.ToPersistence(VehicleHistorys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(VehicleHistory VehicleHistory)
        {
            var persistence = MapperVehicleHistory.ToPersistence(VehicleHistory);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<VehicleHistory> VehicleHistorys)
        {
            var persistences = MapperVehicleHistory.ToPersistence(VehicleHistorys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<VehicleHistory> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<VehicleDeliveryPersistence>(conf => conf.Id == id);
            var VehicleHistory = MapperVehicleHistory.ToModel(persistence);
            return VehicleHistory;
        }

        public async Task<List<VehicleHistory>> GetAll()
        {
            var persistences = await DBConnection.Table<VehicleDeliveryPersistence>().OrderBy(m => m.Id).ToListAsync();
            var VehicleHistorys = MapperVehicleHistory.ToModel(persistences);
            return VehicleHistorys;
        }

        public async Task<int> Insert(VehicleDeliveryPersistence VehicleHistoryPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(VehicleHistoryPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<VehicleDeliveryPersistence> VehicleHistorysPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(VehicleHistorysPersistence);
            return result;
        }

        public async Task<int> Delete(VehicleDeliveryPersistence VehicleHistoryPersistence)
        {
            var result = await DBConnection.DeleteAsync(VehicleHistoryPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<VehicleDeliveryPersistence> VehicleHistorysPersistence)
        {
            var result = await DBConnection.DeleteAsync(VehicleHistorysPersistence);
            return result;
        }

        public async Task<int> Update(VehicleDeliveryPersistence VehicleHistoryPersistence)
        {
            var result = await DBConnection.UpdateAsync(VehicleHistoryPersistence);
            return result;
        }

        public async Task<int> Update(List<VehicleDeliveryPersistence> VehicleHistorysPersistence)
        {
            var result = await DBConnection.UpdateAsync(VehicleHistorysPersistence);
            return result;
        }

    }
}
