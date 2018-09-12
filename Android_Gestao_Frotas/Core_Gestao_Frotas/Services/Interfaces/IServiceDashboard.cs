using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceDashboard
    {
        Task<string> GetRequestsForApproval();

        Task<string> GetRequestsUnavailable();

        Task<string> GetRequestsActiveAll();

        Task<string> GetRequestsActiveUser(User user);

        Task<string> GetRequestsActiveUserVehicle(User user, Vehicle vehicle);

        Task<string> GetRequestsCurso(User user);

        Task<string> GetFuels();

        Task<string> GetBrands();

        Task<string> GetTypologies();

        Task<string> GetModels();

        Task<string> GetVehicles();

        Task<string> GetVehiclesHistory();

        Task<string> GetDamagesVehicle();

        Task<string> GetDamageVehicleDocuments();

        Task<string> GetRequestJustificationTypes();

        Task<string> GetRequestStates();

        Task<string> GetRequests();

        Task<string> GetRequestJustifications();

        Task<string> GetRequestHistories();

        Task<string> ChangeUserPassword(User user);

        Task<string> ApproveRequest(RequestHistory requesthistory);

        Task<string> CancelRequest(RequestHistory requesthistory);

        Task<string> AddJustification(RequestJustification requestJustification, int conflitID);
    }
}
