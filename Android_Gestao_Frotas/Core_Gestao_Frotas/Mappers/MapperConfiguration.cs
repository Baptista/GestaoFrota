using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    public class MapperConfiguration
    {
        public static ConfigurationPersistence ToPersistence(Configuration configuration)
        {
            var configurationPersistence = new ConfigurationPersistence() {
                Id = configuration.Id,
                Parameter = configuration.Parameter,
                Description = configuration.Description
            };

            return configurationPersistence;
        }

        public static List<ConfigurationPersistence> ToPersistence(List<Configuration> configurations)
        {
            var configurationsPersistence = new List<ConfigurationPersistence>();

            foreach (var configuration in configurations)
            {
                configurationsPersistence.Add(new ConfigurationPersistence() {
                    Id = configuration.Id,
                    Parameter = configuration.Parameter,
                    Description = configuration.Description
                });
            }

            return configurationsPersistence;
        }

        public static Configuration ToModel(ConfigurationPersistence configurationPersistence)
        {
            var configuration = new Configuration() {
                Id = configurationPersistence.Id,
                Parameter = configurationPersistence.Parameter,
                Description = configurationPersistence.Description
            };

            return configuration;
        }

        public static List<Configuration> ToModel(List<ConfigurationPersistence> configurationsPersistence)
        {
            var configurations = new List<Configuration>();

            foreach (var configurationPersistence in configurationsPersistence)
            {
                configurations.Add(new Configuration()
                {
                    Id = configurationPersistence.Id,
                    Parameter = configurationPersistence.Parameter,
                    Description = configurationPersistence.Description
                });
            }

            return configurations;
        }
    }
}
