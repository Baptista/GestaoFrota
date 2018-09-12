using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.Configurations
{
    public class RepositoryConfigurationMock : BaseRepository, IRepositoryConfiguration
    {
        public Task<int> Delete(Configuration configuration)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(ConfigurationPersistence configurationPersistence)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAll(List<Configuration> configurations)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAll(List<ConfigurationPersistence> configurationsPersistence)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Configuration>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> GetDefaultPassword()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Configuration configuration)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(ConfigurationPersistence configurationPersistence)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAll(List<Configuration> configurations)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAll(List<ConfigurationPersistence> configurationsPersistence)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Configuration configuration)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(List<Configuration> configurations)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ConfigurationPersistence configurationPersistence)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(List<ConfigurationPersistence> configurationsPersistence)
        {
            throw new NotImplementedException();
        }
    }
}
