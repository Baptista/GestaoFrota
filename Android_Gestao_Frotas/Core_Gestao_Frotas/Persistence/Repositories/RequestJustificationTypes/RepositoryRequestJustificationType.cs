using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.RequestJustificationTypes
{
    class RepositoryRequestJustificationType: BaseRepository, IRepositoryRequestJustificationType
    {

        public async Task<int> Insert(RequestJustificationType RequestJustificationType)
        {
            var persistence = MapperRequestJustificationType.ToPersistence(RequestJustificationType);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestJustificationType> RequestJustificationTypes)
        {
            var persistences = MapperRequestJustificationType.ToPersistence(RequestJustificationTypes);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(RequestJustificationType RequestJustificationType)
        {
            var persistence = MapperRequestJustificationType.ToPersistence(RequestJustificationType);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestJustificationType> RequestJustificationTypes)
        {
            var persistences = MapperRequestJustificationType.ToPersistence(RequestJustificationTypes);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(RequestJustificationType RequestJustificationType)
        {
            var persistence = MapperRequestJustificationType.ToPersistence(RequestJustificationType);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<RequestJustificationType> RequestJustificationTypes)
        {
            var persistences = MapperRequestJustificationType.ToPersistence(RequestJustificationTypes);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<RequestJustificationType> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<RequestJustificationTypePersistence>(conf => conf.Id == id);
            var RequestJustificationType = MapperRequestJustificationType.ToModel(persistence);
            return RequestJustificationType;
        }

        public async Task<List<RequestJustificationType>> GetAll()
        {
            var persistences = await DBConnection.Table<RequestJustificationTypePersistence>().OrderBy(m => m.Id).ToListAsync();
            var RequestJustificationTypes = MapperRequestJustificationType.ToModel(persistences);
            return RequestJustificationTypes;
        }

        public async Task<int> Insert(RequestJustificationTypePersistence RequestJustificationTypePersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(RequestJustificationTypePersistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(RequestJustificationTypesPersistence);
            return result;
        }

        public async Task<int> Delete(RequestJustificationTypePersistence RequestJustificationTypePersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestJustificationTypePersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestJustificationTypesPersistence);
            return result;
        }

        public async Task<int> Update(RequestJustificationTypePersistence RequestJustificationTypePersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestJustificationTypePersistence);
            return result;
        }

        public async Task<int> Update(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestJustificationTypesPersistence);
            return result;
        }

    }
}
