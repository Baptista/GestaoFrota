using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperRequestHistory
    {

        public static RequestHistoryPersistence ToPersistence(RequestHistory requestHistory)
        {
            var requestHistoryPersistence = new RequestHistoryPersistence()
            {
                Id = requestHistory.Id,
                Active = (byte) (requestHistory.Active ? 1 : 0),
                EndDate = requestHistory.EndDate,
                StartDate = requestHistory.StartDate,
                IdVehicle = requestHistory.Vehicle.Id,
                IdUser = requestHistory.User.Id,
                IdRequestState = requestHistory.RequestState.Id,
                IdRequest = requestHistory.Request.Id
            };

            return requestHistoryPersistence;
        }

        public static List<RequestHistoryPersistence> ToPersistence(List<RequestHistory> requestHistorys)
        {
            var requestHistorysPersistence = new List<RequestHistoryPersistence>();

            foreach (var requestHistory in requestHistorys)
            {
                requestHistorysPersistence.Add(new RequestHistoryPersistence()
                {
                    Id = requestHistory.Id,
                    Active = (byte) (requestHistory.Active ? 1 : 0),
                    EndDate = requestHistory.EndDate,
                    StartDate = requestHistory.StartDate,
                    IdVehicle = requestHistory.Vehicle.Id,
                    IdUser = requestHistory.User.Id,
                    IdRequestState = requestHistory.RequestState.Id,
                    IdRequest = requestHistory.Request.Id
                });
            }

            return requestHistorysPersistence;
        }

        public static RequestHistory ToModel(RequestHistoryPersistence requestHistoryPersistence)
        {
            var requestHistory = new RequestHistory()
            {
                Id = requestHistoryPersistence.Id,
                Active = requestHistoryPersistence.Active == 1 ? true : false,
                EndDate = requestHistoryPersistence.EndDate,
                StartDate = requestHistoryPersistence.StartDate,
                Vehicle = new Vehicle() { Id = requestHistoryPersistence.IdVehicle, IsIncomplete = true },
                User = new User() { Id = requestHistoryPersistence.IdUser, IsIncomplete = true },
                RequestState = new RequestState() { Id = requestHistoryPersistence.IdRequestState, IsIncomplete = true },
                Request = new Request() { Id = requestHistoryPersistence.IdRequest, IsIncomplete = true },
            };

            return requestHistory;
        }

        public static List<RequestHistory> ToModel(List<RequestHistoryPersistence> requestHistorysPersistence)
        {
            var requestHistorys = new List<RequestHistory>();

            foreach (var requestHistoryPersistence in requestHistorysPersistence)
            {
                requestHistorys.Add(new RequestHistory()
                {
                    Id = requestHistoryPersistence.Id,
                    Active = requestHistoryPersistence.Active == 1 ? true : false,
                    EndDate = requestHistoryPersistence.EndDate,
                    StartDate = requestHistoryPersistence.StartDate,
                    Vehicle = new Vehicle() { Id = requestHistoryPersistence.IdVehicle, IsIncomplete = true },
                    User = new User() { Id = requestHistoryPersistence.IdUser, IsIncomplete = true },
                    RequestState = new RequestState() { Id = requestHistoryPersistence.IdRequestState, IsIncomplete = true },
                    Request = new Request() { Id = requestHistoryPersistence.IdRequest, IsIncomplete = true },
                });
            }

            return requestHistorys;
        }

    }
}
