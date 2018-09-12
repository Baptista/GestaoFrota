using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.DamageVehicleDocuments
{
    class RepositoryDamageVehicleDocument : BaseRepository, IRepositoryDamageVehicleDocument
    {

        public async Task<int> Insert(DamageVehicleDocument DamageVehicleDocument)
        {
            var persistence = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocument);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<DamageVehicleDocument> DamageVehicleDocuments)
        {
            var persistences = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocuments);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(DamageVehicleDocument DamageVehicleDocument)
        {
            var persistence = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocument);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<DamageVehicleDocument> DamageVehicleDocuments)
        {
            var persistences = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocuments);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(DamageVehicleDocument DamageVehicleDocument)
        {
            var persistence = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocument);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<DamageVehicleDocument> DamageVehicleDocuments)
        {
            var persistences = MapperDamageVehicleDocument.ToPersistence(DamageVehicleDocuments);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<DamageVehicleDocument> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<DamageVehicleDocumentPersistence>(conf => conf.Id == id);
            var DamageVehicleDocument = MapperDamageVehicleDocument.ToModel(persistence);
            return DamageVehicleDocument;
        }

        public async Task<List<DamageVehicleDocument>> GetAll()
        {
            var persistences = await DBConnection.Table<DamageVehicleDocumentPersistence>().OrderBy(m => m.Id).ToListAsync();
            var DamageVehicleDocuments = MapperDamageVehicleDocument.ToModel(persistences);
            return DamageVehicleDocuments;
        }

        public async Task<int> Insert(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(DamageVehicleDocumentPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(DamageVehicleDocumentsPersistence);
            return result;
        }

        public async Task<int> Delete(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence)
        {
            var result = await DBConnection.DeleteAsync(DamageVehicleDocumentPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence)
        {
            var result = await DBConnection.DeleteAsync(DamageVehicleDocumentsPersistence);
            return result;
        }

        public async Task<int> Update(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence)
        {
            var result = await DBConnection.UpdateAsync(DamageVehicleDocumentPersistence);
            return result;
        }

        public async Task<int> Update(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence)
        {
            var result = await DBConnection.UpdateAsync(DamageVehicleDocumentsPersistence);
            return result;
        }

    }
}
