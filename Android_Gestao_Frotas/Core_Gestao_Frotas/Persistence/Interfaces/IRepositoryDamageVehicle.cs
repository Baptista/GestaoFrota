using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryDamageVehicle
    {

        Task<int> Insert(DamageVehicle DamageVehicle);

        Task<int> InsertAll(List<DamageVehicle> DamageVehicles);

        Task<int> Delete(DamageVehicle DamageVehicle);

        Task<int> DeleteAll(List<DamageVehicle> DamageVehicles);

        Task<int> Update(DamageVehicle DamageVehicle);

        Task<int> Update(List<DamageVehicle> DamageVehicles);

        Task<int> Insert(DamageVehiclePersistence DamageVehiclePersistence);

        Task<int> InsertAll(List<DamageVehiclePersistence> DamageVehiclesPersistence);

        Task<int> Delete(DamageVehiclePersistence DamageVehiclePersistence);

        Task<int> DeleteAll(List<DamageVehiclePersistence> DamageVehiclesPersistence);

        Task<int> Update(DamageVehiclePersistence DamageVehiclePersistence);

        Task<int> Update(List<DamageVehiclePersistence> DamageVehiclesPersistence);

        Task<DamageVehicle> Get(int id);

        Task<List<DamageVehicle>> GetAll();

    }
}
