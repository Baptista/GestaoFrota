using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperRequest
    {

        public static RequestPersistence ToPersistence(Request Request)
        {
            var RequestPersistence = new RequestPersistence()
            {
                Id = Request.Id,
                Date = Request.RequestDate,
                //TODO
                //User = Request.IdUser
            };

            return RequestPersistence;
        }

        public static List<RequestPersistence> ToPersistence(List<Request> Requests)
        {
            var RequestsPersistence = new List<RequestPersistence>();

            foreach (var Request in Requests)
            {
                RequestsPersistence.Add(new RequestPersistence()
                {
                    Id = Request.Id,
                    Date = Request.RequestDate,
                    //TODO
                    //User = Request.IdUser
                });
            }

            return RequestsPersistence;
        }

        public static Request ToModel(RequestPersistence requestPersistence)
        {
            var Request = new Request()
            {
                Id = requestPersistence.Id,
                RequestDate = requestPersistence.Date,
                User = new User() { Id = requestPersistence.IdUser, IsIncomplete = true }
            };

            return Request;
        }

        public static List<Request> ToModel(List<RequestPersistence> RequestsPersistence)
        {
            var Requests = new List<Request>();

            foreach (var RequestPersistence in RequestsPersistence)
            {
                Requests.Add(new Request()
                {
                    Id = RequestPersistence.Id,
                    RequestDate = RequestPersistence.Date,
                    //TODO
                    //User = RequestPersistence.IdUser
                });
            }

            return Requests;
        }

    }
}