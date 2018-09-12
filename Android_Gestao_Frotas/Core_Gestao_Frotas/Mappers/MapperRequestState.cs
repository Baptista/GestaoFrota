using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperRequestState
    {

        public static RequestStatePersistence ToPersistence(RequestState RequestState)
        {
            var RequestStatePersistence = new RequestStatePersistence()
            {
                Id = RequestState.Id,
                Description = RequestState.Description
            };

            return RequestStatePersistence;
        }

        public static List<RequestStatePersistence> ToPersistence(List<RequestState> RequestStates)
        {
            var RequestStatesPersistence = new List<RequestStatePersistence>();

            foreach (var RequestState in RequestStates)
            {
                RequestStatesPersistence.Add(new RequestStatePersistence()
                {
                    Id = RequestState.Id,
                    Description = RequestState.Description
                });
            }

            return RequestStatesPersistence;
        }

        public static RequestState ToModel(RequestStatePersistence RequestStatePersistence)
        {
            var RequestState = new RequestState()
            {
                Id = RequestStatePersistence.Id,
                Description = RequestStatePersistence.Description
            };

            return RequestState;
        }

        public static List<RequestState> ToModel(List<RequestStatePersistence> RequestStatesPersistence)
        {
            var RequestStates = new List<RequestState>();

            foreach (var RequestStatePersistence in RequestStatesPersistence)
            {
                RequestStates.Add(new RequestState()
                {
                    Id = RequestStatePersistence.Id,
                    Description = RequestStatePersistence.Description
                });
            }

            return RequestStates;
        }

    }
}