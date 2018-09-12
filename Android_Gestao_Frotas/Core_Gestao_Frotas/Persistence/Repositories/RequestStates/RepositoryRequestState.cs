using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.RequestStates
{
    class RepositoryRequestState: BaseRepository, IRepositoryRequestState
    {

        public async Task<int> Insert(RequestState RequestState)
        {
            var persistence = MapperRequestState.ToPersistence(RequestState);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestState> RequestStates)
        {
            var persistences = MapperRequestState.ToPersistence(RequestStates);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(RequestState RequestState)
        {
            var persistence = MapperRequestState.ToPersistence(RequestState);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestState> RequestStates)
        {
            var persistences = MapperRequestState.ToPersistence(RequestStates);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(RequestState RequestState)
        {
            var persistence = MapperRequestState.ToPersistence(RequestState);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<RequestState> RequestStates)
        {
            var persistences = MapperRequestState.ToPersistence(RequestStates);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<RequestState> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<RequestStatePersistence>(conf => conf.Id == id);
            var RequestState = MapperRequestState.ToModel(persistence);
            return RequestState;
        }

        public async Task<List<RequestState>> GetAll()
        {
            var persistences = await DBConnection.Table<RequestStatePersistence>().OrderBy(m => m.Id).ToListAsync();
            var RequestStates = MapperRequestState.ToModel(persistences);
            return RequestStates;
        }

        public async Task<int> Insert(RequestStatePersistence RequestStatePersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(RequestStatePersistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestStatePersistence> RequestStatesPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(RequestStatesPersistence);
            return result;
        }

        public async Task<int> Delete(RequestStatePersistence RequestStatePersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestStatePersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestStatePersistence> RequestStatesPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestStatesPersistence);
            return result;
        }

        public async Task<int> Update(RequestStatePersistence RequestStatePersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestStatePersistence);
            return result;
        }

        public async Task<int> Update(List<RequestStatePersistence> RequestStatesPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestStatesPersistence);
            return result;
        }

    }
}
