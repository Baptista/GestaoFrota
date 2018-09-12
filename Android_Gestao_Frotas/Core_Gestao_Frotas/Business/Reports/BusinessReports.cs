using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Dashboard;
using Core_Gestao_Frotas.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Reports
{
    public class BusinessReports : BaseBusiness, IBusinessReports
    {
        public async Task<List<Vehicle>> GetAllActiveVehicles()
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var vehicles = new List<Vehicle>();
            vehicles = await repositoryVehicle.GetAll();//.GetAllVehiclesForUser(userId, onlyActive);

            foreach (var vehicle in vehicles)
            {
                var model = await repositoryModel.Get(vehicle.Model.Id);
                var brand = await repositoryBrand.Get(model.Brand.Id);
                var typology = await repositoryTypology.Get(vehicle.Typology.Id);
                var fuel = await repositoryFuel.Get(model.Fuel.Id);

                model.Brand = brand;
                vehicle.Model = model;
                vehicle.Typology = typology;
                vehicle.Model.Fuel = fuel;

                if (vehicle.User.Id != User.Null)
                {
                    var user = await repositoryUser.Get(vehicle.User.Id);
                    vehicle.User = user;
                }
                else
                {
                    var user = new User() { Id = BaseModel.Null, Name = "Edge", Username = "Empresa" };
                    vehicle.User = user;
                }
            }

            return vehicles;
        }

        public async Task<List<VehicleHistory>> GetAllVehicleHistory()
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();
            IRepositoryVehicleHistory repositoryVehicleHistory = new RepositoryVehicleHistory();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var vehiclesHistoryJson = await serviceDashboard.GetVehiclesHistory();
            var vehiclesHistoryPersistence = JsonConvert.DeserializeObject<List<VehicleDeliveryPersistence>>(vehiclesHistoryJson);
            var vehicleHistoryResult = await repositoryVehicleHistory.InsertAll(vehiclesHistoryPersistence);
            var VehiclesHistory = await repositoryVehicleHistory.GetAll();

            var vehicles = await repositoryVehicle.GetAll();
            var requestsHistory = await repositoryRequestHistory.GetAll();
            var models = await repositoryModel.GetAll();
            var users = await repositoryUser.GetAll();
            var brands = await repositoryBrand.GetAll();

            for (int i = 0; i < VehiclesHistory.Count; i++)
            {
                for (int o = 0; o < requestsHistory.Count; o++)
                {
                    if (VehiclesHistory[i].RequestHistory.Id == requestsHistory[o].Id)
                    {
                        VehiclesHistory[i].RequestHistory = requestsHistory[o];
                    }
                }
            }

            for (int i = 0; i < VehiclesHistory.Count; i++)
            {
                for (int o = 0; o < vehicles.Count; o++)
                {
                    if (VehiclesHistory[i].RequestHistory.Vehicle.Id == vehicles[o].Id)
                    {
                        VehiclesHistory[i].RequestHistory.Vehicle = vehicles[o];
                    }
                }
            }

            for (int i = 0; i < VehiclesHistory.Count; i++)
            {
                for (int o = 0; o < models.Count; o++)
                {
                    if (VehiclesHistory[i].RequestHistory.Vehicle.Model.Id == models[o].Id)
                    {
                        VehiclesHistory[i].RequestHistory.Vehicle.Model = models[o];
                    }
                }
            }

            for (int i = 0; i < VehiclesHistory.Count; i++)
            {
                for (int o = 0; o < users.Count; o++)
                {
                    if (VehiclesHistory[i].RequestHistory.User.Id == users[o].Id)
                    {
                        VehiclesHistory[i].RequestHistory.User = users[o];
                    }
                }
            }

            for (int i = 0; i < VehiclesHistory.Count; i++)
            {
                for (int o = 0; o < brands.Count; o++)
                {
                    if (VehiclesHistory[i].RequestHistory.Vehicle.Model.Brand.Id == brands[o].Id)
                    {
                        VehiclesHistory[i].RequestHistory.Vehicle.Model.Brand = brands[o];
                    }
                }
            }

            return VehiclesHistory;
        }

        public async Task<List<User>> GetSelectableUsers()
        {
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            var users = await repositoryUser.GetActiveUsers();

            var profiles = await repositoryProfile.GetAll();

            for (int i = 0; i < users.Count; i++)
            {
                for (int o = 0; o < profiles.Count; o++)
                {
                    if (users[i].Profile.Id == profiles[o].Id)
                    {
                        users[i].Profile = profiles[o];
                    }
                }
            }
            //users.Insert(0, new User() { Id = BaseModel.Null, Name = "Edge", Username = "Empresa" });

            return users;
        }
    }
}
