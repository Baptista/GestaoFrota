using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Persistence.Repositories.Fuels;
using Core_Gestao_Frotas.Persistence.Repositories.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.ModelInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.ModelInfo
{
    public class BusinessModelInfo : BaseBusiness, IBusinessModelInfo
    {
        public async Task<List<Brand>> GetAllActiveBrandsAsync()
        {
            IRepositoryBrand repositoryBrand = new RepositoryBrand();

            var brands = await repositoryBrand.GetAll();

            return brands;
        }

        public async Task<List<Fuel>> GetAllActiveFuelsAsync()
        {
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var fuels = await repositoryFuel.GetAll();

            return fuels;
        }

        public async Task<Model> GetModelAsync(int id)
        {
            IRepositoryModel repositoryModel = new RepositoryModel();
            IRepositoryBrand repositoryBrand = new RepositoryBrand();
            IRepositoryFuel repositoryFuel = new RepositoryFuel();

            var model = await repositoryModel.Get(id);

            if (model.Brand.IsIncomplete)
            {
                var brand = await repositoryBrand.Get(model.Brand.Id);
                model.Brand = brand;
            }

            if (model.Fuel.IsIncomplete)
            {
                var fuel = await repositoryFuel.Get(model.Fuel.Id);
                model.Fuel = fuel;
            }

            return model;
        }

        public async Task<bool> NewModelAsync(Model model)
        {
            IServiceModelInfo serviceModelInfo = new ServiceModelInfo();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var modelJson = await serviceModelInfo.NewModel(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(modelJson);

            var result = await repositoryModel.Insert(modelPersistence[0]);

            return true;
        }

        public async Task<bool> UpdateModelAsync(Model model, bool changeState = false)
        {
            IServiceModelInfo serviceModelInfo = new ServiceModelInfo();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var modelJson = await serviceModelInfo.UpdateModel(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(modelJson);

            var result = await repositoryModel.Update(modelPersistence[0]);

            if (changeState)
                await ChangeModelState(model);

            return true;
        }

        public async Task<bool> ChangeModelState(Model model)
        {
            IServiceModelInfo serviceModelInfo = new ServiceModelInfo();
            IRepositoryModel repositoryModel = new RepositoryModel();

            var modelJson = await serviceModelInfo.ChangeModelState(model);

            var modelPersistence = JsonConvert.DeserializeObject<List<ModelPersistence>>(modelJson);

            var result = await repositoryModel.Update(modelPersistence[0]);

            return result == 1 ? true : false;
        }

        public User GetCurrentUser()
        {
            return _user;
        }
    }
}
