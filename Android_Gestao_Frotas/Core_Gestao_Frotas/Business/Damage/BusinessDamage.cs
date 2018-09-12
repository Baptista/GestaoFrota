using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicleDocuments;
using Core_Gestao_Frotas.Persistence.Repositories.DamageVehicles;
using Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys;
using Core_Gestao_Frotas.Persistence.Repositories.VehicleHistorys;
using Core_Gestao_Frotas.Services.Damage;
using Core_Gestao_Frotas.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Damage
{
    public class BusinessDamage : BaseBusiness, IBusinessDamage
    {
        public async Task<bool> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            IServiceDamage ServiceRequests = new ServiceDamage();
            IRepositoryVehicleHistory repositoryVehicleHistory = new RepositoryVehicleHistory();

            var addvehiclehistory = await ServiceRequests.AddVeiculoHistorico(vehicleHistory);

            var vehiclehistorypersistence = JsonConvert.DeserializeObject<List<VehicleDeliveryPersistence>>(addvehiclehistory);
            var result = await repositoryVehicleHistory.Insert(vehiclehistorypersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<bool> TerminaPedido(RequestHistory requesthistory)
        {
            IServiceDamage ServiceRequests = new ServiceDamage();
            IRepositoryRequestHistory repositoryRequestHistory = new RepositoryRequestHistory();

            var addrequesthistory = await ServiceRequests.TerminaPedido(requesthistory);

            var requestHistoryPersistence = JsonConvert.DeserializeObject<List<RequestHistoryPersistence>>(addrequesthistory);
            var result = await repositoryRequestHistory.Update(requestHistoryPersistence[0]);

            return result == 1 ? true : false;
        }

        public async Task<int> AddDano(DamageVehicle damageVehicle)
        {
            IServiceDamage ServiceRequests = new ServiceDamage();
            IRepositoryDamageVehicle repositoryVehicleDamage = new RepositoryDamageVehicle();

            var adddamagevehicle = await ServiceRequests.AddDano(damageVehicle);

            var vehiclehistorypersistence = JsonConvert.DeserializeObject<List<DamageVehiclePersistence>>(adddamagevehicle);
            var result = await repositoryVehicleDamage.Insert(vehiclehistorypersistence[0]);

            return result == 1 ? vehiclehistorypersistence[0].Id : -1;
        }

        public async Task<bool> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            IServiceDamage ServiceRequests = new ServiceDamage();
            IRepositoryDamageVehicleDocument repositoryDamageVehicleDocument = new RepositoryDamageVehicleDocument();

            var adddamagevehicledocument = await ServiceRequests.AddDanoComprovativo(damageVehicleDocument);

            //var DamageVehicleDocumentPersistence = JsonConvert.DeserializeObject<List<DamageVehicleDocumentPersistence>>(adddamagevehicledocument);
            //var result = await repositoryDamageVehicleDocument.Insert(DamageVehicleDocumentPersistence[0]);

            //return result == 1 ? true : false;
            return true;
        }
    }
}
