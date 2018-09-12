using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceDamage
    {
        Task<string> AddVeiculoHistorico(VehicleHistory vehicleHistory);
        Task<string> TerminaPedido(RequestHistory requesthistory);
        Task<string> AddDano(DamageVehicle damageVehicle);
        Task<string> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument);
    }
}
