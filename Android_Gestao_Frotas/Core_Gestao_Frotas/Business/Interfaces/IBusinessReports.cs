using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessReports
    {
        Task<List<User>> GetSelectableUsers();

        Task<List<Vehicle>> GetAllActiveVehicles();

        Task<List<VehicleHistory>> GetAllVehicleHistory();
    }
}
