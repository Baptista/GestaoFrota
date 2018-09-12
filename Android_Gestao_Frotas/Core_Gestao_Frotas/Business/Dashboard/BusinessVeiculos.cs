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
using Core_Gestao_Frotas.Services.Vehicles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Dashboard
{
    public class BusinessVeiculos : BaseBusiness, IBusinessVeiculos
    {

        public async Task<IEnumerable<Brand>> GetBrands(bool usePersistence = false)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var brandsJson = await serviceVehicle.GetBrands();
            var brands2 = JsonConvert.DeserializeObject<List<BrandPersistence>>(brandsJson);
            var brandResult = await repositoryBrand.InsertAll(brands2);
            var brands = await repositoryBrand.GetAll();

            return brands;
        }

        public async Task<IEnumerable<Model>> GetModels(bool usePersistence = false)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryFuel repositoryFuels = new RepositoryFuel();
            IRepositoryBrand repositoryBrands = new RepositoryBrand();

            var models = new List<Model>();

            if (usePersistence)
            {
                models = await repositoryModel.GetAll();
            }
            else
            {
                var modelsJson = await serviceVehicle.GetModels();
                var models2 = JsonConvert.DeserializeObject<List<ModelPersistence>>(modelsJson);
                var modelsResult = await repositoryModel.InsertAll(models2);
                models = await repositoryModel.GetAll();
            }
            

            for (int i = 0; i <= models.Count - 1; i++)
            {
                if (models[i].Brand.IsIncomplete == true)
                {
                    models[i].Brand = await repositoryBrands.Get(models[i].Brand.Id);
                }
                if (models[i].Fuel.IsIncomplete == true)
                {
                    models[i].Fuel = await repositoryFuels.Get(models[i].Fuel.Id);
                }
            }

            return models;
        }
        public async Task<IEnumerable<Typology>> GetTypologies(bool usePersistence = false)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryTypology repositoryTypologys = new RepositoryTypology();

            var typologies = new List<Typology>();

            if (usePersistence)
            {
                typologies = await repositoryTypologys.GetAll();
            }
            else
            {
                var typologysJson = await serviceVehicle.GetTypologys();
                var typologys2 = JsonConvert.DeserializeObject<List<TypologyPersistence>>(typologysJson);
                var typologysResult = await repositoryTypologys.InsertAll(typologys2);
                typologies = await repositoryTypologys.GetAll();
            }

            return typologies;
        }
        public async Task<IEnumerable<Vehicle>> GetVehicles(bool usePersistence = false)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();

            IRepositoryVehicle repositoryVehicles = new RepositoryVehicle();
            IRepositoryUser repositoryUsers = new RepositoryUser();
            IRepositoryModel repositoryModels = new RepositoryModel();
            IRepositoryTypology repositoryTypologys = new RepositoryTypology();
            IRepositoryBrand repositoryBrands = new RepositoryBrand();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var vehicles = new List<Vehicle>();

            if (usePersistence)
            {
                vehicles = await repositoryVehicles.GetAll();
            }
            else
            {
                var vehiclesJson = await serviceVehicle.GetVehicles();
                var vehiclesPersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(vehiclesJson);
                var vehiclesResult = await repositoryVehicles.InsertAll(vehiclesPersistence);
                vehicles = MapperVehicle.ToModel(vehiclesPersistence);
            }

            foreach (var vehicle in vehicles)
            {
                if (vehicle.User.IsIncomplete)
                    vehicle.User = await repositoryUsers.Get(vehicle.User.Id);

                if (vehicle.Typology.IsIncomplete)
                    vehicle.Typology = await repositoryTypologys.Get(vehicle.Typology.Id);

                if (vehicle.Model.IsIncomplete)
                    vehicle.Model = await repositoryModels.Get(vehicle.Model.Id);

                if (vehicle.Model.Brand.IsIncomplete)
                    vehicle.Model.Brand = await repositoryBrands.Get(vehicle.Model.Brand.Id);

                if (vehicle.Model.Fuel.IsIncomplete)
                    vehicle.Model.Fuel = await repositoryFuel.Get(vehicle.Model.Fuel.Id);
            }

            return vehicles;
        }

        public async Task<IEnumerable<Fuel>> GetFuels(bool usePersistence = false)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryFuel repositoryFuels = new RepositoryFuel();

            var fuels = new List<Fuel>();

            if (usePersistence)
            {
                fuels = await repositoryFuels.GetAll();
            }
            else
            {
                var fuelsJson = await serviceVehicle.GetFuels();
                var fuels2 = JsonConvert.DeserializeObject<List<FuelPersistence>>(fuelsJson);
                var fuelsResult = await repositoryFuels.InsertAll(fuels2);
                fuels = await repositoryFuels.GetAll();
            }

            return fuels;
        }

        public async Task<bool> InsertMarca(Brand brand)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var addbrand = await serviceVehicle.InsertBrand(brand);

            var brandPersistence = JsonConvert.DeserializeObject<List<BrandPersistence>>(addbrand);
            var result = await repositoryBrand.Insert(brandPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> InsertModel(Model model)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var addmodel = await serviceVehicle.InsertModel(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(addmodel);
            var result = await repositoryModel.Insert(modelPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> InsertTypology(Typology typology)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var addtypology = await serviceVehicle.InsertTypology(typology);

            var typologyPersistence = JsonConvert.DeserializeObject<List<TypologyPersistence>>(addtypology);
            var result = await repositoryTypology.Insert(typologyPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> UpdateMarca(Brand brand)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var updatebrand = await serviceVehicle.UpdateBrand(brand);

            var brandPersistence = JsonConvert.DeserializeObject<List<BrandPersistence>>(updatebrand);
            var result = await repositoryBrand.Update(brandPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> UpdateModel(Model model)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var updatemodel = await serviceVehicle.UpdateModel(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(updatemodel);
            var result = await repositoryModel.Update(modelPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> UpdateTypology(Typology typology)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var updatetypology = await serviceVehicle.UpdateTypology(typology);

            var typologyPersistence = JsonConvert.DeserializeObject<List<TypologyPersistence>>(updatetypology);
            var result = await repositoryTypology.Update(typologyPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> UpdateAllModel(Brand brand)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var updatemodel = await serviceVehicle.UpdateAllModel(brand);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(updatemodel);
            var result = 0;

            for (int i = 0; i <= modelPersistence.Count - 1; i++)
            {
                 result = result + await repositoryModel.Update(modelPersistence[0]);
            }

            if (result == modelPersistence.Count)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result == 1 ? true : false;
        }

        public async Task<bool> ChangeMarcaState(Brand brand)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var updatebrand = await serviceVehicle.ChangeBrandState(brand);

            var brandPersistence = JsonConvert.DeserializeObject<List<BrandPersistence>>(updatebrand);
            var result = await repositoryBrand.Update(brandPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> ChangeModelState(Model model)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var updatemodel = await serviceVehicle.ChangeModelState(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(updatemodel);
            var result = await repositoryModel.Update(modelPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> ChangeTypologyState(Typology typology)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var updatetypology = await serviceVehicle.ChangeTypologyState(typology);

            var typologyPersistence = JsonConvert.DeserializeObject<List<TypologyPersistence>>(updatetypology);
            var result = await repositoryTypology.Update(typologyPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> ChangeVehicleState(Vehicle vehicle)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();

            var updatevehicle = await serviceVehicle.ChangeVehicleState(vehicle);

            var vehiclePersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(updatevehicle);
            var result = await repositoryVehicle.Update(vehiclePersistence[0]);

            return result == 1 ? true : false;
        }
    }
}
