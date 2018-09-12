using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessDashboard
    {
        Task<IEnumerable<RequestHistory>> GetRequestsForApproval();

        Task<IEnumerable<RequestHistory>> GetRequestsUnavailable();

        Task<IEnumerable<RequestHistory>> GetRequestsActiveAll();

        Task<IEnumerable<RequestHistory>> GetRequestsActiveUser(User user);

        Task<IEnumerable<RequestHistory>> GetRequestsActiveUserVehicle(User user, Vehicle vehicle);

        Task<IEnumerable<RequestHistory>> GetRequestsEncourse();

        Task<IEnumerable<Vehicle>> GetVehiclesRepository();

        Task<IEnumerable<User>> GetUsersRepository();

        Task<IEnumerable<VehicleHistory>> GetVehicleHistory();

        Task<bool> ChangeUserPassword(User user);

        Task<User> GetNewUser(User user);

        Task<IEnumerable<Configuration>> GetConfigurations();

        Task<bool> LoadVehicles();

        Task<bool> LoadRequests();

        Task<bool> ApproveRequest(RequestHistory request);

        Task<bool> CancelRequest(RequestHistory request);

        Task<bool> AddJustification(RequestJustification requestJustification, int conflitID);

        Task<RequestHistory> GetRequestHistory(int id);
    }
}
