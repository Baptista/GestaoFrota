using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Requests
{
    public class ServiceRequestsMock : BaseService, IServiceRequests
    {
        public Task<string> AddDano(DamageVehicle damageVehicle)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddRequestVehicle(Request request)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddRequestVehicleHistory(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            throw new NotImplementedException();
        }

        public Task<string> AprovaPedido(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetVeiculosDisponiveis(String datainicio, String Datafim)
        {
            throw new NotImplementedException();
        }

        public Task<string> TerminaPedido(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }
    }
}
