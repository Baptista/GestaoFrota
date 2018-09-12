using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Typologys
{
    public class RepositoryTypology: BaseRepository, IRepositoryTypology
    {

        public async Task<int> Insert(Typology Typology)
        {
            var persistence = MapperTypology.ToPersistence(Typology);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Typology> Typologys)
        {
            var persistences = MapperTypology.ToPersistence(Typologys);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Typology Typology)
        {
            var persistence = MapperTypology.ToPersistence(Typology);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Typology> Typologys)
        {
            var persistences = MapperTypology.ToPersistence(Typologys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Typology Typology)
        {
            var persistence = MapperTypology.ToPersistence(Typology);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Typology> Typologys)
        {
            var persistences = MapperTypology.ToPersistence(Typologys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Typology> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<TypologyPersistence>(conf => conf.Id == id);
            var Typology = MapperTypology.ToModel(persistence);
            return Typology;
        }

        public async Task<List<Typology>> GetAll()
        {
            var persistences = await DBConnection.Table<TypologyPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Typologys = MapperTypology.ToModel(persistences);
            return Typologys;
        }

        public async Task<int> Insert(TypologyPersistence TypologyPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(TypologyPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<TypologyPersistence> TypologysPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(TypologysPersistence);
            return result;
        }

        public async Task<int> Delete(TypologyPersistence TypologyPersistence)
        {
            var result = await DBConnection.DeleteAsync(TypologyPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<TypologyPersistence> TypologysPersistence)
        {
            var result = await DBConnection.DeleteAsync(TypologysPersistence);
            return result;
        }

        public async Task<int> Update(TypologyPersistence TypologyPersistence)
        {
            var result = await DBConnection.UpdateAsync(TypologyPersistence);
            return result;
        }

        public async Task<int> Update(List<TypologyPersistence> TypologysPersistence)
        {
            var result = await DBConnection.UpdateAsync(TypologysPersistence);
            return result;
        }

    }
}
