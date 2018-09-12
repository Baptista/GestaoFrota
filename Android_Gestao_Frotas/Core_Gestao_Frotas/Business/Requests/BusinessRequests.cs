using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicleDocuments;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicles;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Requests;
using Core_Gestao_Frotas.Persistence.Repositories.Typologys;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.Vehicles;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Requests
{
    public class BusinessRequests : BaseBusiness, IBusinessRequests
    {
        public async Task<int> AddDano(DamageVehicle damageVehicle)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryDamageVehicle repositoryVehicleDamage = new RepositoryDamageVehicle();

            var adddamagevehicle = await ServiceRequests.AddDano(damageVehicle);

            var vehiclehistorypersistence = JsonConvert.DeserializeObject<List<DamageVehiclePersistence>>(adddamagevehicle);
            var result = await repositoryVehicleDamage.Insert(vehiclehistorypersistence[0]);

            return result == 1 ? vehiclehistorypersistence[0].Id : -1;
        }

        public async Task<bool> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryDamageVehicleDocument repositoryDamageVehicleDocument = new RepositoryDamageVehicleDocument();

            var adddamagevehicledocument = await ServiceRequests.AddDanoComprovativo(damageVehicleDocument);

            //var DamageVehicleDocumentPersistence = JsonConvert.DeserializeObject<List<DamageVehicleDocumentPersistence>>(adddamagevehicledocument);
            //var result = await repositoryDamageVehicleDocument.Insert(DamageVehicleDocumentPersistence[0]);

            //return result == 1 ? true : false;
            return true;
        }

        public async Task<bool> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryVehicleHistory repositoryVehicleHistory = new RepositoryVehicleHistory();

            var addvehiclehistory = await ServiceRequests.AddVeiculoHistorico(vehicleHistory);

            var vehiclehistorypersistence = JsonConvert.DeserializeObject<List<VehicleDeliveryPersistence>>(addvehiclehistory);
            var result = await repositoryVehicleHistory.Insert(vehiclehistorypersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> AproveRequest(RequestHistory requesthistory)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await ServiceRequests.AprovaPedido(requesthistory);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Update(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Vehicle>> GetVeiculosDisponiveis(String datainicio, String Datafim)
        {
            IServiceRequests servicerequests = new ServiceRequests();
            IRepositoryUser repositoryUsers = new RepositoryUser();
            IRepositoryModel repositoryModels = new RepositoryModel();
            IRepositoryTypology repositoryTypologys = new RepositoryTypology();
            IRepositoryBrand repositoryBrands = new RepositoryBrand();

            var vehiclesJson = await servicerequests.GetVeiculosDisponiveis(datainicio, Datafim);
            var vehicles2 = JsonConvert.DeserializeObject<List<VehiclePersistence>>(vehiclesJson);
            var vehicles = MapperVehicle.ToModel(vehicles2);

            for (int i = 0; i <= vehicles.Count - 1; i++)
            {
                if (vehicles[i].User.IsIncomplete == true)
                {
                    vehicles[i].User = await repositoryUsers.Get(vehicles[i].User.Id);
                }
                if (vehicles[i].Typology.IsIncomplete == true)
                {
                    vehicles[i].Typology = await repositoryTypologys.Get(vehicles[i].Typology.Id);
                }
                if (vehicles[i].Model.IsIncomplete == true)
                {
                    vehicles[i].Model = await repositoryModels.Get(vehicles[i].Model.Id);
                    vehicles[i].Model.Brand = await repositoryBrands.Get(vehicles[i].Model.Brand.Id);
                }
            }

            return vehicles;
        }

        public async Task<int> InsertRequest(Request request)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryRequest repositoryRequest = new RepositoryRequest();

            var addrequest = await ServiceRequests.AddRequestVehicle(request);

            var requestPersistence = JsonConvert.DeserializeObject<List<RequestPersistence>>(addrequest);
            var result = await repositoryRequest.Insert(requestPersistence[0]);

            return requestPersistence[0].Id;
        }

        public async Task<bool> InsertRequestHistory(RequestHistory requesthistory)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await ServiceRequests.AddRequestVehicleHistory(requesthistory);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Insert(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> TerminaPedido(RequestHistory requesthistory)
        {
            IServiceRequests ServiceRequests = new ServiceRequests();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await ServiceRequests.TerminaPedido(requesthistory);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Update(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }
    }
}
