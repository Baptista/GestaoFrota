using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceVehicleInfo
    {
        Task<string> ChangeVehicleState(Vehicle vehicle);

        Task<string> NewVehicle(Vehicle vehicle);

        Task<string> UpdateVehicle(Vehicle vehicle);
    }
}
