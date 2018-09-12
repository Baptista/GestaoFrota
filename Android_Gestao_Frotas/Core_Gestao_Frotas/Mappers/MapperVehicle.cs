using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Users;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    public class MapperVehicle
    {
        public static VehiclePersistence ToPersistence(Vehicle Vehicle)
        {
            var VehiclePersistence = new VehiclePersistence()
            {
                Id = Vehicle.Id,
                Active = (byte)(Vehicle.Active == true ? 1 : 0),
                Available = (byte)(Vehicle.Available == true ? 1 : 0),
                ContractKms = Vehicle.ContractKms,
                LicensePlate = Vehicle.LicensePlate,
                StartKms = Vehicle.StartKms,
                IdModel = Vehicle.Model.Id,
                IdTypology = Vehicle.Typology.Id,
                IdUser = Vehicle.User.Id.ToString()
            };

            return VehiclePersistence;
        }

        public static List<VehiclePersistence> ToPersistence(List<Vehicle> Vehicles)
        {
            var VehiclesPersistence = new List<VehiclePersistence>();

            foreach (var Vehicle in Vehicles)
            {
                VehiclesPersistence.Add(new VehiclePersistence()
                {
                    Id = Vehicle.Id,
                    Active = (byte)(Vehicle.Active == true ? 1 : 0),
                    Available = (byte)(Vehicle.Available == true ? 1 : 0),
                    ContractKms = Vehicle.ContractKms,
                    LicensePlate = Vehicle.LicensePlate,
                    StartKms = Vehicle.StartKms,
                    IdModel = Vehicle.Model.Id,
                    IdTypology = Vehicle.Typology.Id,
                    IdUser = Vehicle.User.Id.ToString()
                });
            }

            return VehiclesPersistence;
        }

        public static Vehicle ToModel(VehiclePersistence VehiclePersistence)
        {
            var Vehicle = new Vehicle()
            {
                Id = VehiclePersistence.Id,
                Active = VehiclePersistence.Active == 1 ? true : false,
                Available = VehiclePersistence.Available == 1 ? true : false,
                ContractKms = VehiclePersistence.ContractKms,
                LicensePlate = VehiclePersistence.LicensePlate,
                StartKms = VehiclePersistence.StartKms,
                User = string.IsNullOrEmpty(VehiclePersistence.IdUser) ? 
                            new User() { Id = BaseModel.Null, Username = "Empresa", Name = "Edge" } : 
                            new User() { Id = Int32.Parse(VehiclePersistence.IdUser), IsIncomplete = true } ,
                Typology =  new Typology() { Id = VehiclePersistence.IdTypology, IsIncomplete = true },
                Model = new Model() { Id = VehiclePersistence.IdModel, IsIncomplete = true }
            };

            return Vehicle;
        }

        public static List<Vehicle> ToModel(List<VehiclePersistence> VehiclesPersistence)
        {
            var Vehicles = new List<Vehicle>();

            foreach (var VehiclePersistence in VehiclesPersistence)
            {
                Vehicles.Add(new Vehicle()
                {
                    Id = VehiclePersistence.Id,
                    Active = VehiclePersistence.Active == 1 ? true : false,
                    Available = VehiclePersistence.Available == 1 ? true : false,
                    ContractKms = VehiclePersistence.ContractKms,
                    LicensePlate = VehiclePersistence.LicensePlate,
                    StartKms = VehiclePersistence.StartKms,
                    User = string.IsNullOrEmpty(VehiclePersistence.IdUser) ?
                                new User() { Id = BaseModel.Null, Username = "Empresa", Name = "Edge" } :
                                new User() { Id = Int32.Parse(VehiclePersistence.IdUser), IsIncomplete = true },
                    Typology = new Typology() { Id = VehiclePersistence.IdTypology, IsIncomplete = true },
                    Model = new Model() { Id = VehiclePersistence.IdModel, IsIncomplete = true }
                });
            }

            return Vehicles;
        }

    }
}