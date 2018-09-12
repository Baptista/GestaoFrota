using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperFuel
    {

        public static FuelPersistence ToPersistence(Fuel Fuel)
        {
            var FuelPersistence = new FuelPersistence()
            {
                Id = Fuel.Id,
                Description = Fuel.Description
            };

            return FuelPersistence;
        }

        public static List<FuelPersistence> ToPersistence(List<Fuel> Fuels)
        {
            var FuelsPersistence = new List<FuelPersistence>();

            foreach (var Fuel in Fuels)
            {
                FuelsPersistence.Add(new FuelPersistence()
                {
                    Id = Fuel.Id,
                    Description = Fuel.Description
                });
            }

            return FuelsPersistence;
        }

        public static Fuel ToModel(FuelPersistence FuelPersistence)
        {
            var Fuel = new Fuel()
            {
                Id = FuelPersistence.Id,
                Description = FuelPersistence.Description
            };

            return Fuel;
        }

        public static List<Fuel> ToModel(List<FuelPersistence> FuelsPersistence)
        {
            var Fuels = new List<Fuel>();

            foreach (var FuelPersistence in FuelsPersistence)
            {
                Fuels.Add(new Fuel()
                {
                    Id = FuelPersistence.Id,
                    Description = FuelPersistence.Description
                });
            }

            return Fuels;
        }

    }
}