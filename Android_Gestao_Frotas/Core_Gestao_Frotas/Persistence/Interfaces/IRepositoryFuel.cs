using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryFuel
    {

        Task<int> Insert(Fuel Fuel);

        Task<int> InsertAll(List<Fuel> Fuels);

        Task<int> Delete(Fuel Fuel);

        Task<int> DeleteAll(List<Fuel> Fuels);

        Task<int> Update(Fuel Fuel);

        Task<int> Update(List<Fuel> Fuels);

        Task<int> Insert(FuelPersistence FuelPersistence);

        Task<int> InsertAll(List<FuelPersistence> FuelsPersistence);

        Task<int> Delete(FuelPersistence FuelPersistence);

        Task<int> DeleteAll(List<FuelPersistence> FuelsPersistence);

        Task<int> Update(FuelPersistence FuelPersistence);

        Task<int> Update(List<FuelPersistence> FuelsPersistence);

        Task<Fuel> Get(int id);

        Task<List<Fuel>> GetAll();

    }
}
