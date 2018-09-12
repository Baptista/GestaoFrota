using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryRequest
    {

        Task<int> Insert(Request Request);

        Task<int> InsertAll(List<Request> Requests);

        Task<int> Delete(Request Request);

        Task<int> DeleteAll(List<Request> Requests);

        Task<int> Update(Request Request);

        Task<int> Update(List<Request> Requests);

        Task<int> Insert(RequestPersistence RequestPersistence);

        Task<int> InsertAll(List<RequestPersistence> RequestsPersistence);

        Task<int> Delete(RequestPersistence RequestPersistence);

        Task<int> DeleteAll(List<RequestPersistence> RequestsPersistence);

        Task<int> Update(RequestPersistence RequestPersistence);

        Task<int> Update(List<RequestPersistence> RequestsPersistence);

        Task<Request> Get(int id);

        Task<List<Request>> GetAll();

    }
}
