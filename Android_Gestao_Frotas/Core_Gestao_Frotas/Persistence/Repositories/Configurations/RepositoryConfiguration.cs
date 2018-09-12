using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.Configurations
{
    public class RepositoryConfiguration : BaseRepository, IRepositoryConfiguration
    {
        public const string DefaultPassword = "password";

        public async Task<int> Insert(Configuration configuration)
        {
            var persistence = MapperConfiguration.ToPersistence(configuration);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Configuration> configurations)
        {
            var persistences = MapperConfiguration.ToPersistence(configurations);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Configuration configuration)
        {
            var persistence = MapperConfiguration.ToPersistence(configuration);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Configuration> configurations)
        {
            var persistences = MapperConfiguration.ToPersistence(configurations);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Configuration configuration)
        {
            var persistence = MapperConfiguration.ToPersistence(configuration);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Configuration> configurations)
        {
            var persistences = MapperConfiguration.ToPersistence(configurations);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Configuration> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<ConfigurationPersistence>(conf => conf.Id == id);
            var configuration = MapperConfiguration.ToModel(persistence);
            return configuration;
        }

        public async Task<List<Configuration>> GetAll()
        {
            var persistences = await DBConnection.Table<ConfigurationPersistence>().OrderBy(m => m.Id).ToListAsync();
            var configurations = MapperConfiguration.ToModel(persistences);
            return configurations;
        }

        public async Task<int> Insert(ConfigurationPersistence configurationPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(configurationPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<ConfigurationPersistence> configurationsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(configurationsPersistence);
            return result;
        }

        public async Task<int> Delete(ConfigurationPersistence configurationPersistence)
        {
            var result = await DBConnection.DeleteAsync(configurationPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<ConfigurationPersistence> configurationsPersistence)
        {
            var result = await DBConnection.DeleteAsync(configurationsPersistence);
            return result;
        }

        public async Task<int> Update(ConfigurationPersistence configurationPersistence)
        {
            var result = await DBConnection.UpdateAsync(configurationPersistence);
            return result;
        }

        public async Task<int> Update(List<ConfigurationPersistence> configurationsPersistence)
        {
            var result = await DBConnection.UpdateAsync(configurationsPersistence);
            return result;
        }

        public async Task<Configuration> GetDefaultPassword()
        {
            var result = await DBConnection.GetAsync<ConfigurationPersistence>(conf => conf.Parameter == DefaultPassword);
            var configuration = MapperConfiguration.ToModel(result);
            return configuration;
        }
    }
}
