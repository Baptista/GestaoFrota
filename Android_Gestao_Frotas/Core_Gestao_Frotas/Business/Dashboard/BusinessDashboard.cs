using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Configurations;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicleDocuments;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicles;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Permissions;
using Core_Gestao_Frotas.Persistence.Repositories.ProfilePermission;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.RequestJustifications;
using Core_Gestao_Frotas.Persistence.Repositories.RequestJustificationTypes;
using Core_Gestao_Frotas.Persistence.Repositories.Requests;
using Core_Gestao_Frotas.Persistence.Repositories.RequestStates;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Dashboard;
using Core_Gestao_Frotas.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Dashboard
{
    public class BusinessDashboard : BaseBusiness, IBusinessDashboard
    {
        public async Task<IEnumerable<RequestHistory>> GetRequestsForApproval()
        {
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();
            IRepositoryRequestState repositoryRequestState = new RepositoryRequestState();

            var requestHistoriesForApproval = new List<RequestHistory>();
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests))
                requestHistoriesForApproval = await repositoryRequestHistory.GetTopThreeRequestHistoriesForApproval();
            else
                requestHistoriesForApproval = await repositoryRequestHistory.GetTopThreeRequestHistoriesForApproval(AllYouCanGet.CurrentUser.Id);

            if (requestHistoriesForApproval != null && requestHistoriesForApproval.Count > 0)
            {
                foreach (var requestHistoryForApproval in requestHistoriesForApproval)
                {
                    if (requestHistoryForApproval.Request.IsIncomplete)
                    {
                        var request = await repositoryRequest.Get(requestHistoryForApproval.Request.Id);
                        var requestUser = await GetUser(request.User.Id);
                        request.User = requestUser;
                        requestHistoryForApproval.Request = request;
                    }

                    if (requestHistoryForApproval.RequestState.IsIncomplete)
                    {
                        var requestState = await repositoryRequestState.Get(requestHistoryForApproval.RequestState.Id);
                        requestHistoryForApproval.RequestState = requestState;
                    }

                    if (requestHistoryForApproval.Vehicle.IsIncomplete)
                    {
                        var vehicle = await GetVehicle(requestHistoryForApproval.Vehicle.Id);
                        requestHistoryForApproval.Vehicle = vehicle;
                    }

                    if (requestHistoryForApproval.User.IsIncomplete)
                    {
                        var user = await GetUser(requestHistoryForApproval.User.Id);
                        requestHistoryForApproval.User = user;
                    }
                }
            }
            else
            {
                return new List<RequestHistory>();
            }            

            return requestHistoriesForApproval;
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsUnavailable()
        {
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();
            IRepositoryRequestState repositoryRequestState = new RepositoryRequestState();

            var requestHistoriesUnavailable = new List<RequestHistory>();
            if (AllYouCanGet.CurrentUser.Profile.Id == 1 || AllYouCanGet.CurrentUser.Profile.Id == 2)
                requestHistoriesUnavailable = await repositoryRequestHistory.GetTopThreeRequestHistoriesUnavailable();
            else
                requestHistoriesUnavailable = await repositoryRequestHistory.GetTopThreeRequestHistoriesUnavailable(AllYouCanGet.CurrentUser.Id);
            
            if (requestHistoriesUnavailable != null && requestHistoriesUnavailable.Count > 0)
            {
                foreach (var requestHistoryForApproval in requestHistoriesUnavailable)
                {
                    if (requestHistoryForApproval.Request.IsIncomplete)
                    {
                        var request = await repositoryRequest.Get(requestHistoryForApproval.Request.Id);
                        var requestUser = await GetUser(request.User.Id);
                        request.User = requestUser;
                        requestHistoryForApproval.Request = request;
                    }

                    if (requestHistoryForApproval.RequestState.IsIncomplete)
                    {
                        var requestState = await repositoryRequestState.Get(requestHistoryForApproval.RequestState.Id);
                        requestHistoryForApproval.RequestState = requestState;
                    }

                    if (requestHistoryForApproval.Vehicle.IsIncomplete)
                    {
                        var vehicle = await GetVehicle(requestHistoryForApproval.Vehicle.Id);
                        requestHistoryForApproval.Vehicle = vehicle;
                    }

                    if (requestHistoryForApproval.User.IsIncomplete)
                    {
                        var user = await GetUser(requestHistoryForApproval.User.Id);
                        requestHistoryForApproval.User = user;
                    }
                }
            }
            else
            {
                return new List<RequestHistory>();
            }

            return requestHistoriesUnavailable;
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsEncourse()
        {
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();
            IRepositoryRequestState repositoryRequestState = new RepositoryRequestState();

            var requestHistoriesEncourse = new List<RequestHistory>();
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequestsEncourse))
                requestHistoriesEncourse = await repositoryRequestHistory.GetTopThreeRequestHistoriesEncourse();
            else
                requestHistoriesEncourse = await repositoryRequestHistory.GetTopThreeRequestHistoriesEncourse(AllYouCanGet.CurrentUser.Id);

            if (requestHistoriesEncourse != null && requestHistoriesEncourse.Count > 0)
            {
                foreach (var requestHistoryEncourse in requestHistoriesEncourse)
                {
                    if (requestHistoryEncourse.Request.IsIncomplete)
                    {
                        var request = await repositoryRequest.Get(requestHistoryEncourse.Request.Id);
                        var requestUser = await GetUser(request.User.Id);
                        request.User = requestUser;
                        requestHistoryEncourse.Request = request;
                    }

                    if (requestHistoryEncourse.RequestState.IsIncomplete)
                    {
                        var requestState = await repositoryRequestState.Get(requestHistoryEncourse.RequestState.Id);
                        requestHistoryEncourse.RequestState = requestState;
                    }

                    if (requestHistoryEncourse.Vehicle.IsIncomplete)
                    {
                        var vehicle = await GetVehicle(requestHistoryEncourse.Vehicle.Id);
                        requestHistoryEncourse.Vehicle = vehicle;
                    }

                    if (requestHistoryEncourse.User.IsIncomplete)
                    {
                        var user = await GetUser(requestHistoryEncourse.User.Id);
                        requestHistoryEncourse.User = user;
                    }
                }
            }
            else
            {
                return new List<RequestHistory>();
            }

            return requestHistoriesEncourse;
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsActiveAll()
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();

            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var requestsActiveJson = await serviceDashboard.GetRequestsActiveAll();
            var requestsHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(requestsActiveJson);
            var requestsHistory = MapperRequestHistory.ToModel(requestsHistoryPersistence);

            for (int i = 0; i <= requestsHistory.Count - 1; i++)
            {
                if (requestsHistory[i].Vehicle.IsIncomplete == true)
                {
                    requestsHistory[i].Vehicle = await repositoryVehicle.Get(requestsHistory[i].Vehicle.Id);
                    requestsHistory[i].Vehicle.Model = await repositoryModel.Get(requestsHistory[i].Vehicle.Model.Id);
                }

                if (requestsHistory[i].User.IsIncomplete == true)
                {
                    requestsHistory[i].User = await repositoryUser.Get(requestsHistory[i].User.Id);
                }
            }

            return requestsHistory;
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsActiveUser(User user)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();

            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var requestsActiveJson = await serviceDashboard.GetRequestsActiveUser(user);
            var requestsHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(requestsActiveJson);
            var requestsHistory = MapperRequestHistory.ToModel(requestsHistoryPersistence);

            for (int i = 0; i <= requestsHistory.Count - 1; i++)
            {
                if (requestsHistory[i].Vehicle.IsIncomplete == true)
                {
                    requestsHistory[i].Vehicle = await repositoryVehicle.Get(requestsHistory[i].Vehicle.Id);
                    requestsHistory[i].Vehicle.Model = await repositoryModel.Get(requestsHistory[i].Vehicle.Model.Id);
                }

                if (requestsHistory[i].User.IsIncomplete == true)
                {
                    requestsHistory[i].User = await repositoryUser.Get(requestsHistory[i].User.Id);
                }
            }

            return requestsHistory;
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsActiveUserVehicle(User user, Vehicle vehicle)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();

            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryUser repositoryUser = new RepositoryUser();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var requestsActiveJson = await serviceDashboard.GetRequestsActiveUserVehicle(user,vehicle);
            var requestsHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(requestsActiveJson);
            var requestsHistory = MapperRequestHistory.ToModel(requestsHistoryPersistence);

            for (int i = 0; i <= requestsHistory.Count - 1; i++)
            {
                if (requestsHistory[i].Vehicle.IsIncomplete == true)
                {
                    requestsHistory[i].Vehicle = await repositoryVehicle.Get(requestsHistory[i].Vehicle.Id);
                    requestsHistory[i].Vehicle.Model = await repositoryModel.Get(requestsHistory[i].Vehicle.Model.Id);
                }

                if (requestsHistory[i].User.IsIncomplete == true)
                {
                    requestsHistory[i].User = await repositoryUser.Get(requestsHistory[i].User.Id);
                }
            }

            return requestsHistory;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesRepository()
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();

            var vehicles = await repositoryVehicle.GetAll();

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Model.IsIncomplete == true)
                {
                    vehicles[i].Model = await GetModel(vehicles[i].Model.Id);
                }
            }

            return vehicles;
        }

        public async Task<IEnumerable<User>> GetUsersRepository()
        {
            IRepositoryUser repositoryUser = new RepositoryUser();

            var users = await repositoryUser.GetAll();

            return users;
        }

        public async Task<bool> ChangeUserPassword(User user)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();
            IRepositoryUser repositoryUser = new RepositoryUser();

            var updateuser = await serviceDashboard.ChangeUserPassword(user);

            var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(updateuser);
            var result = await repositoryUser.Update(userPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Configuration>> GetConfigurations()
        {
            IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();

            var configurations = await repositoryConfiguration.GetAll();

            return configurations;
        }

        public async Task<User> GetNewUser(User user)
        {
            IRepositoryUser repositoryUser = new RepositoryUser();

            var userget = await repositoryUser.Get(user.Id);

            return userget;
        }

        public async Task<IEnumerable<VehicleHistory>> GetVehicleHistory()
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();

            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var vehicleHistoryJson = await serviceDashboard.GetVehiclesHistory();
            var vehicleHistoryPersistence = JsonConvert.DeserializeObject<List<VehicleDeliveryPersistence>>(vehicleHistoryJson);
            var vehicleHistory = MapperVehicleHistory.ToModel(vehicleHistoryPersistence);

            //for (int i = 0; i <= vehicleHistory.Count - 1; i++)
            //{
             //   if (vehicleHistory[i].RequestHistory.IsIncomplete == true)
              //  {
                        //vehicleHistory[i].RequestHistory = await repositoryRequestHistory.Get(vehicleHistory[i].RequestHistory.Id);
             //   }
           // }

            return vehicleHistory;
        }

        public async Task<bool> LoadVehicles()
        {
            try
            {
                IServiceDashboard serviceDashboard = new ServiceDashboard();

                IRepositoryFuel repositoryFuel = new RepositoryFuel();
                IRepositoryBrand repositoryBrand = new RepositoryBrand();
                IRepositoryTypology repositoryTypology = new RepositoryTypology();
                IRepositoryModel repositoryModel = new RepositoryModel();
                IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
                IRepositoryVehicleHistory repositoryVehicleHistory = new RepositoryVehicleHistory();
                IRepositoryDamageVehicle repositoryDamageVehicle = new RepositoryDamageVehicle();
                IRepositoryDamageVehicleDocument repositoryDamageVehicleDocument = new RepositoryDamageVehicleDocument();

                var fuelsJson = await serviceDashboard.GetFuels();
                var brandsJson = await serviceDashboard.GetBrands();
                var typologiesJson = await serviceDashboard.GetTypologies();
                var modelsJson = await serviceDashboard.GetModels();
                var vehiclesJson = await serviceDashboard.GetVehicles();
                var vehiclesHistoryJson = await serviceDashboard.GetVehiclesHistory();
                var damagesVehicleJson = await serviceDashboard.GetDamagesVehicle();
                var damageVehiclesDocumentsJson = await serviceDashboard.GetDamageVehicleDocuments();

                var fuelsPersistence = JsonConvert.DeserializeObject<List<FuelPersistence>>(fuelsJson);
                var brandsPersistence = JsonConvert.DeserializeObject<List<BrandPersistence>>(brandsJson);
                var typologiesPersistence = JsonConvert.DeserializeObject<List<TypologyPersistence>>(typologiesJson);
                var modelsPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(modelsJson);
                var vehiclesPersistence = JsonConvert.DeserializeObject<List<VehiclePersistence>>(vehiclesJson);
                var vehiclesHistoryPersistence = JsonConvert.DeserializeObject<List<VehicleDeliveryPersistence>>(vehiclesHistoryJson);
                var damagesVehiclePersistence = JsonConvert.DeserializeObject<List<DamageVehiclePersistence>>(damagesVehicleJson);
                var damageVehicleDocumentsPersistence = JsonConvert.DeserializeObject<List<DamageVehicleDocumentPersistence>>(damageVehiclesDocumentsJson);

                var fuelResult = await repositoryFuel.InsertAll(fuelsPersistence);
                var brandResult = await repositoryBrand.InsertAll(brandsPersistence);
                var typologyResult = await repositoryTypology.InsertAll(typologiesPersistence);
                var modelResult = await repositoryModel.InsertAll(modelsPersistence);
                var vehicleResult = await repositoryVehicle.InsertAll(vehiclesPersistence);
                var vehicleHistoryResult = await repositoryVehicleHistory.InsertAll(vehiclesHistoryPersistence);
                var damagesVehicleResult = await repositoryDamageVehicle.InsertAll(damagesVehiclePersistence);
                var damageVehicleDocumentResult = await repositoryDamageVehicleDocument.InsertAll(damageVehicleDocumentsPersistence);

                return true;
            }
            catch (Exception exceptionLoadVehicles)
            {
                Debug.WriteLine(exceptionLoadVehicles.StackTrace);
                return false;
            }
        }

        public async Task<bool> LoadRequests()
        {
            try
            {
                IServiceDashboard serviceDashboard = new ServiceDashboard();
                IRepositoryRequestJustificationType repositoryRequestJustificationType = new RepositoryRequestJustificationType();
                IRepositoryRequestState repositoryRequestState = new RepositoryRequestState();
                IRepositoryRequest repositoryRequest = new RepositoryRequest();
                IRepositoryRequestJustification repositoryRequestJustification = new RepositoryRequestJustification();
                IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

                var requestJustificationTypesJson = await serviceDashboard.GetRequestJustificationTypes();
                var requestStatesJson = await serviceDashboard.GetRequestStates();
                var requestsJson = await serviceDashboard.GetRequests();
                var requestJustificationsJson = await serviceDashboard.GetRequestJustifications();
                var requestHistoriesJson = await serviceDashboard.GetRequestHistories();

                var requestJustificationTypesPersistence = JsonConvert.DeserializeObject<List<RequestJustificationTypePersistence>>(requestJustificationTypesJson);
                var requestStatesPersistence = JsonConvert.DeserializeObject<List<RequestStatePersistence>>(requestStatesJson);
                var requestsPersistence = JsonConvert.DeserializeObject<List<RequestPersistence>>(requestsJson);
                var requestJustificationsPersistence = JsonConvert.DeserializeObject<List<RequestJustificationPersistence>>(requestJustificationsJson);
                var requestHistoriesPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(requestHistoriesJson);

                var requestJustificationTypesResult = await repositoryRequestJustificationType.InsertAll(requestJustificationTypesPersistence);
                var requestStatesResult = await repositoryRequestState.InsertAll(requestStatesPersistence);
                var requestsResult = await repositoryRequest.InsertAll(requestsPersistence);
                var requestJustificationsResult = await repositoryRequestJustification.InsertAll(requestJustificationsPersistence);
                var requestHistoriesResult = await repositoryRequestHistory.InsertAll(requestHistoriesPersistence);

                return true;
            }
            catch (Exception exceptionLoadRequests)
            {
                Debug.WriteLine(exceptionLoadRequests.StackTrace);
                return false;
            }
        }

        public async Task<bool> ApproveRequest(RequestHistory requesthistory)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await serviceDashboard.ApproveRequest(requesthistory);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Update(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> CancelRequest(RequestHistory request)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await serviceDashboard.CancelRequest(request);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Update(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }

        #region PrivateHelpers

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

                if (user.Profile.Permissions == null || user.Profile.Permissions.Count == 0)
                {
                    if (user.Profile.Permissions == null)
                        user.Profile.Permissions = new Dictionary<Permission, bool>();

                    var profilePermissionsPersistence = await repositoryProfilePermission.GetAllPermissionsOfProfile(user.Profile.Id);
                    foreach (var profilePermission in profilePermissionsPersistence)
                    {
                        var permission = await repositoryPermission.Get(profilePermission.IdPermission);
                        user.Profile.Permissions.Add(permission, profilePermission.Active == 1 ? true : false);
                    }
                }
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

        private async Task<Vehicle> GetVehicle(int vehicleId)
        {
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();

            var vehicle = await repositoryVehicle.Get(vehicleId);

            if (vehicle.Typology != null && vehicle.Typology.IsIncomplete)
            {
                var typology = await repositoryTypology.Get(vehicle.Typology.Id);
                vehicle.Typology = typology;
            }

            if (vehicle.Model != null && vehicle.Model.IsIncomplete)
            {
                var model = await GetModel(vehicle.Model.Id);
                vehicle.Model = model;
            }

            if (vehicle.User != null && vehicle.User.IsIncomplete)
            {
                var user = await GetUser(vehicle.User.Id);
                vehicle.User = user;
            }

            return vehicle;
        }

        public async Task<bool> AddJustification(RequestJustification requestJustification, int conflitID)
        {
            IServiceDashboard serviceDashboard = new ServiceDashboard();
            IRepositoryRequestJustification repositoryRequestJustification = new RepositoryRequestJustification();

            var addjustification = await serviceDashboard.AddJustification(requestJustification, conflitID);

            var requestJustificationPersistence = JsonConvert.DeserializeObject<List<RequestJustification>>(addjustification);
            var result = await repositoryRequestJustification.Update(requestJustificationPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<RequestHistory> GetRequestHistory(int id)
        {
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();
            IRepositoryVehicle repositoryVehicle = new RepositoryVehicle();
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();
            IRepositoryTypology repositoryTypology = new RepositoryTypology();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();
            IRepositoryRequestState repositoryRequestState = new RepositoryRequestState();

            var requestHistory = await repositoryRequestHistory.Get(id);
            var user = await RepositoryUser.Get(requestHistory.User.Id);
            var vehicle = await repositoryVehicle.Get(requestHistory.Vehicle.Id);
            var model = await repositoryModel.Get(vehicle.Model.Id);
            var brand = await repositoryBrand.Get(model.Brand.Id);
            var typology = await repositoryTypology.Get(vehicle.Typology.Id);
            var fuel = await repositoryFuel.Get(model.Fuel.Id);
            var request = await repositoryRequest.Get(requestHistory.Request.Id);
            var userRequest = await RepositoryUser.Get(request.User.Id);
            var requestState = await repositoryRequestState.Get(requestHistory.RequestState.Id);

            request.User = userRequest;
            requestHistory.Request = request;

            model.Brand = brand;
            model.Fuel = fuel;
            vehicle.Model = model;

            vehicle.Typology = typology;

            vehicle.User = user;

            requestHistory.RequestState = requestState;

            return requestHistory;
        }

        #endregion
    }
}
