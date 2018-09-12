using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryVehicleHistory
    {

        Task<int> Insert(VehicleHistory VehicleHistory);

        Task<int> InsertAll(List<VehicleHistory> VehicleHistorys);

        Task<int> Delete(VehicleHistory VehicleHistory);

        Task<int> DeleteAll(List<VehicleHistory> VehicleHistorys);

        Task<int> Update(VehicleHistory VehicleHistory);

        Task<int> Update(List<VehicleHistory> VehicleHistorys);

        Task<int> Insert(VehicleDeliveryPersistence VehicleHistoryPersistence);

        Task<int> InsertAll(List<VehicleDeliveryPersistence> VehicleHistorysPersistence);

        Task<int> Delete(VehicleDeliveryPersistence VehicleHistoryPersistence);

        Task<int> DeleteAll(List<VehicleDeliveryPersistence> VehicleHistorysPersistence);

        Task<int> Update(VehicleDeliveryPersistence VehicleHistoryPersistence);

        Task<int> Update(List<VehicleDeliveryPersistence> VehicleHistorysPersistence);

        Task<VehicleHistory> Get(int id);

        Task<List<VehicleHistory>> GetAll();

    }
}
