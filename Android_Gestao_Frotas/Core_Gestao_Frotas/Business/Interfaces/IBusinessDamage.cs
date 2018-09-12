using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Interfaces
{
    public interface IBusinessDamage
    {
        Task<bool> AddVeiculoHistorico(VehicleHistory vehicleHistory);

        Task<bool> TerminaPedido(RequestHistory requesthistory);

        Task<int> AddDano(DamageVehicle damageVehicle);

        Task<bool> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument);
    }
}
