using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.DamageVehicles
{
    class RepositoryDamageVehicle : BaseRepository, IRepositoryDamageVehicle
    {

        public async Task<int> Insert(DamageVehicle DamageVehicle)
        {
            var persistence = MapperDamageVehicle.ToPersistence(DamageVehicle);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<DamageVehicle> DamageVehicles)
        {
            var persistences = MapperDamageVehicle.ToPersistence(DamageVehicles);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(DamageVehicle DamageVehicle)
        {
            var persistence = MapperDamageVehicle.ToPersistence(DamageVehicle);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<DamageVehicle> DamageVehicles)
        {
            var persistences = MapperDamageVehicle.ToPersistence(DamageVehicles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(DamageVehicle DamageVehicle)
        {
            var persistence = MapperDamageVehicle.ToPersistence(DamageVehicle);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<DamageVehicle> DamageVehicles)
        {
            var persistences = MapperDamageVehicle.ToPersistence(DamageVehicles);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<DamageVehicle> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<DamageVehiclePersistence>(conf => conf.Id == id);
            var DamageVehicle = MapperDamageVehicle.ToModel(persistence);
            return DamageVehicle;
        }

        public async Task<List<DamageVehicle>> GetAll()
        {
            var persistences = await DBConnection.Table<DamageVehiclePersistence>().OrderBy(m => m.Id).ToListAsync();
            var DamageVehicles = MapperDamageVehicle.ToModel(persistences);
            return DamageVehicles;
        }

        public async Task<int> Insert(DamageVehiclePersistence DamageVehiclePersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(DamageVehiclePersistence);
            return result;
        }

        public async Task<int> InsertAll(List<DamageVehiclePersistence> DamageVehiclesPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(DamageVehiclesPersistence);
            return result;
        }

        public async Task<int> Delete(DamageVehiclePersistence DamageVehiclePersistence)
        {
            var result = await DBConnection.DeleteAsync(DamageVehiclePersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<DamageVehiclePersistence> DamageVehiclesPersistence)
        {
            var result = await DBConnection.DeleteAsync(DamageVehiclesPersistence);
            return result;
        }

        public async Task<int> Update(DamageVehiclePersistence DamageVehiclePersistence)
        {
            var result = await DBConnection.UpdateAsync(DamageVehiclePersistence);
            return result;
        }

        public async Task<int> Update(List<DamageVehiclePersistence> DamageVehiclesPersistence)
        {
            var result = await DBConnection.UpdateAsync(DamageVehiclesPersistence);
            return result;
        }

    }
}
