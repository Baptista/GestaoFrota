using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    public interface IRepositoryConfiguration
    {
        Task<int> Insert(Configuration configuration);

        Task<int> InsertAll(List<Configuration> configurations);

        Task<int> Delete(Configuration configuration);

        Task<int> DeleteAll(List<Configuration> configurations);

        Task<int> Update(Configuration configuration);

        Task<int> Update(List<Configuration> configurations);

        Task<int> Insert(ConfigurationPersistence configurationPersistence);

        Task<int> InsertAll(List<ConfigurationPersistence> configurationsPersistence);

        Task<int> Delete(ConfigurationPersistence configurationPersistence);

        Task<int> DeleteAll(List<ConfigurationPersistence> configurationsPersistence);

        Task<int> Update(ConfigurationPersistence configurationPersistence);

        Task<int> Update(List<ConfigurationPersistence> configurationsPersistence);

        Task<Configuration> Get(int id);

        Task<List<Configuration>> GetAll();

        Task<Configuration> GetDefaultPassword();
    }
}
