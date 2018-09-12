using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Permissions;
using Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Requests;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.NewRequest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.NewRequest
{
    public class BusinessNewRequest : BaseBusiness, IBusinessNewRequest
    {
        public async Task<List<Vehicle>> GetAvailableVehicles(DateTime startDate, DateTime endDate)
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var requestHistoriesBetweenDates = await repositoryRequestHistory.GetRequestHistoriesBetween(startDate, endDate);
            var activeVehicles = await repositoryVehicle.GetAllActiveVehicles();

            var availableVehicles = new List<Vehicle>();
            foreach (var vehicle in activeVehicles)
            {
                var isOccupied = requestHistoriesBetweenDates.Any(request => request.Vehicle.Id == vehicle.Id);
                if (!isOccupied)
                {
                    if (vehicle.Model.IsIncomplete)
                    {
                        var model = await GetModel(vehicle.Model.Id);
                        vehicle.Model = model;
                    }

                    if (vehicle.User.IsIncomplete)
                    {
                        var user = await GetUser(vehicle.User.Id);
                        vehicle.User = user;
                    }

                    if (vehicle.Typology.IsIncomplete)
                    {
                        var typology = await repositoryTypology.Get(vehicle.Typology.Id);
                        vehicle.Typology = typology;
                    }

                    availableVehicles.Add(vehicle);
                } 
            }

            return availableVehicles;
        }

        public async Task<bool> NewRequest(User user, DateTime requestDate, Vehicle vehicle, DateTime startDate, DateTime endDate)
        {
            IServiceNewRequest serviceNewRequest = new ServiceNewRequest();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var request = new Request() { User = user, RequestDate = requestDate };
            var newRequestJson = await serviceNewRequest.NewRequest(request);

            var newRequestPersistence = JsonConvert.DeserializeObject<List<RequestPersistence>>(newRequestJson);
            var newRequestResult = await repositoryRequest.Insert(newRequestPersistence[0]);

            var requestModel = MapperRequest.ToModel(newRequestPersistence[0]);
            if (requestModel.User.IsIncomplete)
                requestModel.User = user;

            var requestHistory = new RequestHistory() { User = user, Vehicle = vehicle, Request = requestModel, StartDate = startDate, EndDate = endDate };
            var newRequestHistoryJson = await serviceNewRequest.NewRequestHistory(requestHistory);

            var newRequestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(newRequestHistoryJson);
            var newRequestHistoryResult = await repositoryRequestHistory.Insert(newRequestHistoryPersistence[0]);

            return newRequestResult > 0 && newRequestHistoryResult > 0;
        }

        private async Task<User> GetUser(int userId)
        {
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryProfile repositoryProfile = new RepositoryProfile();
            IRepositoryProfilePermission repositoryProfilePermission = new RepositoryProfilePermission();
            IRepositoryPermission repositoryPermission = new RepositoryPermission();

            var user = await repositoryUser.Get(userId);

            if (user.Profile != null && user.Profile.IsIncomplete)
            {
                var profile = await repositoryProfile.Get(user.Profile.Id);
                user.Profile = profile;

                //if (user.Profile.Permissions == null || user.Profile.Permissions.Count == 0)
                //{
                //    if (user.Profile.Permissions == null)
                //        user.Profile.Permissions = new Dictionary<Permission, bool>();

                //    var profilePermissionsPersistence = await repositoryProfilePermission.GetAllPermissionsOfProfile(user.Profile.Id);
                //    foreach (var profilePermission in profilePermissionsPersistence)
                //    {
                //        var permission = await repositoryPermission.Get(profilePermission.IdPermission);
                //        user.Profile.Permissions.Add(permission, profilePermission.Active == 1 ? true : false);
                //    }
                //}
            }

            return user;
        }

        private async Task<Model> GetModel(int modelId)
        {
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var model = await repositoryModel.Get(modelId);

            if (model.Brand != null && model.Brand.IsIncomplete)
            {
                var brand = await repositoryBrand.Get(model.Brand.Id);
                model.Brand = brand;
            }

            if (model.Fuel != null && model.Fuel.IsIncomplete)
            {
                var fuel = await repositoryFuel.Get(model.Fuel.Id);
                model.Fuel = fuel;
            }

            return model;
        }

        public async Task<Vehicle> GetVehicle(int vehicleId)
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var vehicle = await repositoryVehicle.Get(vehicleId);
            if (vehicle.Model.IsIncomplete)
            {
                var model = await GetModel(vehicle.Model.Id);
                vehicle.Model = model;
            }

            if (vehicle.User.IsIncomplete)
            {
                var user = await GetUser(vehicle.User.Id);
                vehicle.User = user;
            }

            if (vehicle.Typology.IsIncomplete)
            {
                var typology = await repositoryTypology.Get(vehicle.Typology.Id);
                vehicle.Typology = typology;
            }

            return vehicle;
        }

        public async Task<RequestHistory> ExisteSobreposicao(int IdUtilizador, DateTime startDate, DateTime endDate)
        {
            IServiceNewRequest serviceNewRequest = new ServiceNewRequest();
            var request = await serviceNewRequest.ExisteSobreposicao(IdUtilizador, startDate, endDate);
            RequestHistory requestget = null;
            if (request == "ok")
            {
                requestget = new RequestHistory { Id = -1 };
            }
            else
            {
                var requestPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(request);
                requestget = MapperRequestHistory.ToModel(requestPersistence[0]);
            }
            return requestget;
        }

        public async Task<RequestHistory> GetlastRequestHistory()
        {
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            var list = await repositoryRequestHistory.GetAll();
            RequestHistory requestsend = new RequestHistory { Id = -1};
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id > requestsend.Id)
                {
                    requestsend = list[i];
                }
            }
            return requestsend;
        }
    }
}
