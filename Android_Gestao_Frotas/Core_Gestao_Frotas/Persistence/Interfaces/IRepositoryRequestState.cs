using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryRequestState
    {

        Task<int> Insert(RequestState RequestState);

        Task<int> InsertAll(List<RequestState> RequestStates);

        Task<int> Delete(RequestState RequestState);

        Task<int> DeleteAll(List<RequestState> RequestStates);

        Task<int> Update(RequestState RequestState);

        Task<int> Update(List<RequestState> RequestStates);

        Task<int> Insert(RequestStatePersistence RequestStatePersistence);

        Task<int> InsertAll(List<RequestStatePersistence> RequestStatesPersistence);

        Task<int> Delete(RequestStatePersistence RequestStatePersistence);

        Task<int> DeleteAll(List<RequestStatePersistence> RequestStatesPersistence);

        Task<int> Update(RequestStatePersistence RequestStatePersistence);

        Task<int> Update(List<RequestStatePersistence> RequestStatesPersistence);

        Task<RequestState> Get(int id);

        Task<List<RequestState>> GetAll();

    }
}
