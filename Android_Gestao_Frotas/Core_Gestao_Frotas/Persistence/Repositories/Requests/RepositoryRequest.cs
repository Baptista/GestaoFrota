using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Requests
{
    class RepositoryRequest: BaseRepository, IRepositoryRequest
    {

        public async Task<int> Insert(Request Request)
        {
            var persistence = MapperRequest.ToPersistence(Request);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Request> Requests)
        {
            var persistences = MapperRequest.ToPersistence(Requests);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Request Request)
        {
            var persistence = MapperRequest.ToPersistence(Request);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Request> Requests)
        {
            var persistences = MapperRequest.ToPersistence(Requests);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Request Request)
        {
            var persistence = MapperRequest.ToPersistence(Request);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Request> Requests)
        {
            var persistences = MapperRequest.ToPersistence(Requests);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Request> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<RequestPersistence>(conf => conf.Id == id);
            var Request = MapperRequest.ToModel(persistence);
            return Request;
        }

        public async Task<List<Request>> GetAll()
        {
            var persistences = await DBConnection.Table<RequestPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Requests = MapperRequest.ToModel(persistences);
            return Requests;
        }

        public async Task<int> Insert(RequestPersistence RequestPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(RequestPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestPersistence> RequestsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(RequestsPersistence);
            return result;
        }

        public async Task<int> Delete(RequestPersistence RequestPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestPersistence> RequestsPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestsPersistence);
            return result;
        }

        public async Task<int> Update(RequestPersistence RequestPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestPersistence);
            return result;
        }

        public async Task<int> Update(List<RequestPersistence> RequestsPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestsPersistence);
            return result;
        }

    }
}
