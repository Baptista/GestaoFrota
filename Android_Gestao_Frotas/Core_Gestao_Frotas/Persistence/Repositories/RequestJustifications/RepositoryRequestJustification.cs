using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.RequestJustifications
{
    class RepositoryRequestJustification: BaseRepository, IRepositoryRequestJustification
    {

        public async Task<int> Insert(RequestJustification RequestJustification)
        {
            var persistence = MapperRequestJustification.ToPersistence(RequestJustification);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestJustification> RequestJustifications)
        {
            var persistences = MapperRequestJustification.ToPersistence(RequestJustifications);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(RequestJustification RequestJustification)
        {
            var persistence = MapperRequestJustification.ToPersistence(RequestJustification);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestJustification> RequestJustifications)
        {
            var persistences = MapperRequestJustification.ToPersistence(RequestJustifications);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(RequestJustification RequestJustification)
        {
            var persistence = MapperRequestJustification.ToPersistence(RequestJustification);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<RequestJustification> RequestJustifications)
        {
            var persistences = MapperRequestJustification.ToPersistence(RequestJustifications);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<RequestJustification> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<RequestJustificationPersistence>(conf => conf.Id == id);
            var RequestJustification = MapperRequestJustification.ToModel(persistence);
            return RequestJustification;
        }

        public async Task<List<RequestJustification>> GetAll()
        {
            var persistences = await DBConnection.Table<RequestJustificationPersistence>().OrderBy(m => m.Id).ToListAsync();
            var RequestJustifications = MapperRequestJustification.ToModel(persistences);
            return RequestJustifications;
        }

        public async Task<int> Insert(RequestJustificationPersistence RequestJustificationPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(RequestJustificationPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestJustificationPersistence> RequestJustificationsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(RequestJustificationsPersistence);
            return result;
        }

        public async Task<int> Delete(RequestJustificationPersistence RequestJustificationPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestJustificationPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestJustificationPersistence> RequestJustificationsPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestJustificationsPersistence);
            return result;
        }

        public async Task<int> Update(RequestJustificationPersistence RequestJustificationPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestJustificationPersistence);
            return result;
        }

        public async Task<int> Update(List<RequestJustificationPersistence> RequestJustificationsPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestJustificationsPersistence);
            return result;
        }

    }
}
