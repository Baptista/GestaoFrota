using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperDamageVehicle
    {

        public static DamageVehiclePersistence ToPersistence(DamageVehicle DamageVehicle)
        {
            var DamageVehiclePersistence = new DamageVehiclePersistence()
            {
                Id = DamageVehicle.Id,
                Active = (byte) (DamageVehicle.Active ? 1 : 0),
                Description = DamageVehicle.Description,
                Date = DamageVehicle.Date
                //TODO
                //RequestHistory = DamageVehicle.IdRequestHistory
                //Vehicle = DamageVehicle.IdVehicle
            };

            return DamageVehiclePersistence;
        }

        public static List<DamageVehiclePersistence> ToPersistence(List<DamageVehicle> DamageVehicles)
        {
            var DamageVehiclesPersistence = new List<DamageVehiclePersistence>();

            foreach (var DamageVehicle in DamageVehicles)
            {
                DamageVehiclesPersistence.Add(new DamageVehiclePersistence()
                {
                    Id = DamageVehicle.Id,
                    Active = (byte) (DamageVehicle.Active ? 1 : 0),
                    Description = DamageVehicle.Description,
                    Date = DamageVehicle.Date
                    //TODO
                    //RequestHistory = DamageVehicle.IdRequestHistory
                    //Vehicle = DamageVehicle.IdVehicle
                });
            }

            return DamageVehiclesPersistence;
        }

        public static DamageVehicle ToModel(DamageVehiclePersistence DamageVehiclePersistence)
        {
            var DamageVehicle = new DamageVehicle()
            {
                Id = DamageVehiclePersistence.Id,
                Active = DamageVehiclePersistence.Active == 1 ? true : false,
                Description = DamageVehiclePersistence.Description,
                Date = DamageVehiclePersistence.Date
                //TODO
                //RequestHistory = DamageVehiclePersistence.IdRequestHistory
                //Vehicle = DamageVehiclePersistence.IdVehicle
            };

            return DamageVehicle;
        }

        public static List<DamageVehicle> ToModel(List<DamageVehiclePersistence> DamageVehiclesPersistence)
        {
            var DamageVehicles = new List<DamageVehicle>();

            foreach (var DamageVehiclePersistence in DamageVehiclesPersistence)
            {
                DamageVehicles.Add(new DamageVehicle()
                {
                    Id = DamageVehiclePersistence.Id,
                    Active = DamageVehiclePersistence.Active == 1 ? true : false,
                    Description = DamageVehiclePersistence.Description,
                    Date = DamageVehiclePersistence.Date
                    //TODO
                    //RequestHistory = DamageVehiclePersistence.IdRequestHistory
                    //Vehicle = DamageVehiclePersistence.IdVehicle
                });
            }

            return DamageVehicles;
        }

    }
}
