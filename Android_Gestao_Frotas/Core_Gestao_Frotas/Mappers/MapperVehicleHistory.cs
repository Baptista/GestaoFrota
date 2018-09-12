using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperVehicleHistory
    {

        public static VehicleDeliveryPersistence ToPersistence(VehicleHistory VehicleHistory)
        {
            var VehicleHistoryPersistence = new VehicleDeliveryPersistence()
            {
                Id = VehicleHistory.Id,
                Date = VehicleHistory.Date,
                Kms = VehicleHistory.Kms,
                IdRequestHistory = VehicleHistory.RequestHistory.Id
                //TODO
                //RequestHistory = VehicleHistory.IdRequestHistory
            };

            return VehicleHistoryPersistence;
        }

        public static List<VehicleDeliveryPersistence> ToPersistence(List<VehicleHistory> VehicleHistorys)
        {
            var VehicleHistorysPersistence = new List<VehicleDeliveryPersistence>();

            foreach (var VehicleHistory in VehicleHistorys)
            {
                VehicleHistorysPersistence.Add(new VehicleDeliveryPersistence()
                {
                    Id = VehicleHistory.Id,
                    Date = VehicleHistory.Date,
                    Kms = VehicleHistory.Kms,
                    IdRequestHistory = VehicleHistory.RequestHistory.Id
                    //TODO
                    //RequestHistory = VehicleHistory.IdRequestHistory
                });
            }

            return VehicleHistorysPersistence;
        }

        public static VehicleHistory ToModel(VehicleDeliveryPersistence VehicleHistoryPersistence)
        {
            var VehicleHistory = new VehicleHistory()
            {
                Id = VehicleHistoryPersistence.Id,
                Date = VehicleHistoryPersistence.Date,
                Kms = VehicleHistoryPersistence.Kms,
                RequestHistory = new RequestHistory { Id = VehicleHistoryPersistence.IdRequestHistory, IsIncomplete = true }
                //TODO
                //RequestHistory = VehicleHistoryPersistence.IdRequestHistory
            };

            return VehicleHistory;
        }

        public static List<VehicleHistory> ToModel(List<VehicleDeliveryPersistence> VehicleHistorysPersistence)
        {
            var VehicleHistorys = new List<VehicleHistory>();

            foreach (var VehicleHistoryPersistence in VehicleHistorysPersistence)
            {
                VehicleHistorys.Add(new VehicleHistory()
                {
                    Id = VehicleHistoryPersistence.Id,
                    Date = VehicleHistoryPersistence.Date,
                    Kms = VehicleHistoryPersistence.Kms,
                    RequestHistory = new RequestHistory { Id = VehicleHistoryPersistence.IdRequestHistory, IsIncomplete = true }
                    //TODO
                    //RequestHistory = VehicleHistoryPersistence.IdRequestHistory
                });
            }

            return VehicleHistorys;
        }

    }
}