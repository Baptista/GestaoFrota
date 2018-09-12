using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Vehicles
{
    class ServiceVehicleMock : BaseService, IServiceVehicle
    {
        public Task<string> ChangeBrandState(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeModelState(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeTypologyState(Typology typology)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeVehicleState(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<String> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<String> GetFuels()
        {
            throw new NotImplementedException();
        }

        public Task<String> GetModels()
        {
            throw new NotImplementedException();
        }

        public Task<String> GetTypologys()
        {
            throw new NotImplementedException();
        }

        public Task<String> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<String> InsertBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<String> InsertModel(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<String> InsertTypology(Typology typology)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAllModel(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateModel(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTypology(Typology typology)
        {
            throw new NotImplementedException();
        }
    }

}
