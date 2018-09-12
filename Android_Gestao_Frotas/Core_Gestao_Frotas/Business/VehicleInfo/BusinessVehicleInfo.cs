using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.VehicleInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.VehicleInfo
{
    public class BusinessVehicleInfo : BaseBusiness, IBusinessVehicleInfo
    {
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var brands = await repositoryBrand.GetAll();

            return brands;
        }

        public async Task<IEnumerable<Fuel>> GetFuels()
        {
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var fuels = await repositoryFuel.GetAll();

            return fuels;
        }

        public async Task<IEnumerable<Model>> GetModels()
        {
            IRepositoryModel repositoryModel = new RepositoryModel();

            var models = await repositoryModel.GetAll();

            return models;
        }

        public async Task<IEnumerable<Typology>> GetTypologies()
        {
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var typologies = await repositoryTypology.GetAll();

            return typologies;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IRepositoryUser repositoryUser = new RepositoryUser();

            var users = await repositoryUser.GetAll();
            users.Insert(0, new User() { Id = BaseModel.Null, Name = "Edge", Username = "Empresa" });

            return users;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var vehicle = await repositoryVehicle.Get(id);

            if (vehicle.Model.IsIncomplete)
                vehicle.Model = await repositoryModel.Get(vehicle.Model.Id);

            if (vehicle.Model.Brand.IsIncomplete)
                vehicle.Model.Brand = await repositoryBrand.Get(vehicle.Model.Brand.Id);

            if (vehicle.Model.Fuel.IsIncomplete)
                vehicle.Model.Fuel = await repositoryFuel.Get(vehicle.Model.Fuel.Id);

            if (vehicle.User.IsIncomplete)
                vehicle.User = await repositoryUser.Get(vehicle.User.Id);

            if (vehicle.Typology.IsIncomplete)
                vehicle.Typology = await repositoryTypology.Get(vehicle.Typology.Id);

            return vehicle;
        }

        public async Task<bool> ChangeVehicleState(Vehicle vehicle)
        {
            IServiceVehicleInfo serviceVehicleInfo = new ServiceVehicleInfo();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();

            var updatevehicle = await serviceVehicleInfo.ChangeVehicleState(vehicle);

            var vehiclePersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(updatevehicle);
            var result = await repositoryVehicle.Update(vehiclePersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> NewVehicle(Vehicle vehicle)
        {
            IServiceVehicleInfo serviceVehicleInfo = new ServiceVehicleInfo();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();

            var vehicleJson = await serviceVehicleInfo.NewVehicle(vehicle);

            var vehiclePersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(vehicleJson);

            var result = await repositoryVehicle.Insert(vehiclePersistence[0]);

            return true;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            IServiceVehicleInfo serviceVehicleInfo = new ServiceVehicleInfo();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();

            var vehicleJson = await serviceVehicleInfo.UpdateVehicle(vehicle);

            var vehiclePersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(vehicleJson);

            var result = await repositoryVehicle.Update(vehiclePersistence[0]);

            return true;
        }

        public User GetCurrentUser()
        {
            return _user;
        }
    }
}
