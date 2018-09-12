using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Requests
{
    public class BusinessRequestsMock : BaseBusiness, IBusinessRequests
    {
        public Task<int> AddDano(DamageVehicle damageVehicle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AproveRequest(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVeiculosDisponiveis(string datainicio, string Datafim)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertRequest(Request request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRequestHistory(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TerminaPedido(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }
    }
}
