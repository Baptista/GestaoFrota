using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Models
{
    public class RepositoryModel : BaseRepository, IRepositoryModel
    {

        public async Task<int> Insert(Model Model)
        {
            var persistence = MapperModel.ToPersistence(Model);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Model> Models)
        {
            var persistences = MapperModel.ToPersistence(Models);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Model Model)
        {
            var persistence = MapperModel.ToPersistence(Model);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Model> Models)
        {
            var persistences = MapperModel.ToPersistence(Models);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Model Model)
        {
            var persistence = MapperModel.ToPersistence(Model);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Model> Models)
        {
            var persistences = MapperModel.ToPersistence(Models);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Model> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<ModelPersistence>(conf => conf.Id == id);
            var Model = MapperModel.ToModel(persistence);
            return Model;
        }

        public async Task<List<Model>> GetAll()
        {
            var persistences = await DBConnection.Table<ModelPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Models = MapperModel.ToModel(persistences);
            return Models;
        }

        public async Task<int> Insert(ModelPersistence ModelPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(ModelPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<ModelPersistence> ModelsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(ModelsPersistence);
            return result;
        }

        public async Task<int> Delete(ModelPersistence ModelPersistence)
        {
            var result = await DBConnection.DeleteAsync(ModelPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<ModelPersistence> ModelsPersistence)
        {
            var result = await DBConnection.DeleteAsync(ModelsPersistence);
            return result;
        }

        public async Task<int> Update(ModelPersistence ModelPersistence)
        {
            var result = await DBConnection.UpdateAsync(ModelPersistence);
            return result;
        }

        public async Task<int> Update(List<ModelPersistence> ModelsPersistence)
        {
            var result = await DBConnection.UpdateAsync(ModelsPersistence);
            return result;
        }

    }
}
