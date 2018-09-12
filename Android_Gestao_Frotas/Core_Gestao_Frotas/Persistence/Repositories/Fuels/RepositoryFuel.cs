using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.Fuels
{
    class RepositoryFuel: BaseRepository, IRepositoryFuel
    {

        public async Task<int> Insert(Fuel Fuel)
        {
            var persistence = MapperFuel.ToPersistence(Fuel);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Fuel> Fuels)
        {
            var persistences = MapperFuel.ToPersistence(Fuels);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Fuel Fuel)
        {
            var persistence = MapperFuel.ToPersistence(Fuel);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Fuel> Fuels)
        {
            var persistences = MapperFuel.ToPersistence(Fuels);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Fuel Fuel)
        {
            var persistence = MapperFuel.ToPersistence(Fuel);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Fuel> Fuels)
        {
            var persistences = MapperFuel.ToPersistence(Fuels);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Fuel> Get(int id)
        {
            var persistence = await DBConnection.QueryAsync<FuelPersistence>($"SELECT * FROM FuelPersistence WHERE Id == {id}"); ;// await DBConnection.GetAsync<FuelPersistence>(conf => conf.Id == id);
            if (persistence != null && persistence.Count > 0)
            {
                var fuelModel = MapperFuel.ToModel(persistence[0]);
                return fuelModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Fuel>> GetAll()
        {
            var persistences = await DBConnection.Table<FuelPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Fuels = MapperFuel.ToModel(persistences);
            return Fuels;
        }

        public async Task<int> Insert(FuelPersistence FuelPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(FuelPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<FuelPersistence> FuelsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(FuelsPersistence);
            return result;
        }

        public async Task<int> Delete(FuelPersistence FuelPersistence)
        {
            var result = await DBConnection.DeleteAsync(FuelPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<FuelPersistence> FuelsPersistence)
        {
            var result = await DBConnection.DeleteAsync(FuelsPersistence);
            return result;
        }

        public async Task<int> Update(FuelPersistence FuelPersistence)
        {
            var result = await DBConnection.UpdateAsync(FuelPersistence);
            return result;
        }

        public async Task<int> Update(List<FuelPersistence> FuelsPersistence)
        {
            var result = await DBConnection.UpdateAsync(FuelsPersistence);
            return result;
        }

    }
}
