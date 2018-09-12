using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessNewRequest
    {
        Task<List<Vehicle>> GetAvailableVehicles(DateTime startDate, DateTime endDate);

        Task<bool> NewRequest(User user, DateTime requestDate, Vehicle vehicle, DateTime startDate, DateTime endDate);

        Task<Vehicle> GetVehicle(int vehicleId);

        Task<RequestHistory> ExisteSobreposicao(int IdUtilizador, DateTime startDate, DateTime endDate);

        Task<RequestHistory> GetlastRequestHistory();

    }
}
