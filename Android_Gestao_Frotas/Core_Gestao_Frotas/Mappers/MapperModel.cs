using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Brands;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperModel
    {

        public static ModelPersistence ToPersistence(Model Model)
        {
            IServiceVehicle serviceVehicle = new ServiceVehicle();
            var listabrands = serviceVehicle.GetBrands();

            var ModelPersistence = new ModelPersistence()
            {
                Id = Model.Id,
                Active = (byte)(Model.Active == true ? 1 : 0),
                Description = Model.Description,
                IdBrand = Model.Brand.Id,
                IdFuel = Model.Fuel.Id
                //TODO
                //Fuel = Model.IdFuel
                //Brand = Model.IdBrand
            };

            return ModelPersistence;
        }

        public static List<ModelPersistence> ToPersistence(List<Model> Models)
        {
            var ModelsPersistence = new List<ModelPersistence>();

            foreach (var Model in Models)
            {
                ModelsPersistence.Add(new ModelPersistence()
                {
                    Id = Model.Id,
                    Active = (byte)(Model.Active == true ? 1 : 0),
                    Description = Model.Description,
                    IdBrand = Model.Brand.Id,
                    IdFuel = Model.Fuel.Id
                    //TODO
                    //Fuel = Model.IdFuel
                    //Brand = Model.IdBrand
                });
            }

            return ModelsPersistence;
        }

        public static Model ToModel(ModelPersistence ModelPersistence)
        {

            IRepositoryBrand brandsrepository = new RepositoryBrand();

            var Model = new Model()
            {
                Id = ModelPersistence.Id,
                Active = ModelPersistence.Active == 1 ? true : false,
                Description = ModelPersistence.Description,
                Brand = new Brand() { Id = ModelPersistence.IdBrand, IsIncomplete = true },
                Fuel = new Fuel() { Id = ModelPersistence.IdFuel, IsIncomplete = true }
                //Brand = BusinessVeiculos.ListBrands.FirstOrDefault(brand => { return brand.Id == ModelPersistence.IdBrand; }),
                //Fuel = BusinessVeiculos.ListFuels.FirstOrDefault(fuel => { return fuel.Id == ModelPersistence.IdFuel; }),
                //TODO
                //Fuel = ModelPersistence.IdFuel
                //Brand = ModelPersistence.IdBrand
            };

            return Model;
        }

        public static List<Model> ToModel(List<ModelPersistence> modelsPersistence)
        {
            var models = new List<Model>();
            IRepositoryBrand brandsrepository = new RepositoryBrand();

            foreach (var modelPersistence in modelsPersistence)
            {
                models.Add(new Model()
                {
                    Id = modelPersistence.Id,
                    Active = modelPersistence.Active == 1 ? true : false,
                    Description = modelPersistence.Description,
                    Brand = new Brand() { Id = modelPersistence.IdBrand, IsIncomplete = true },
                    Fuel = new Fuel() { Id = modelPersistence.IdFuel, IsIncomplete = true }
                    //Brand = BusinessVeiculos.ListBrands.FirstOrDefault(brand => { return brand.Id == modelPersistence.IdBrand; }),
                    //Fuel = BusinessVeiculos.ListFuels.FirstOrDefault(fuel => { return fuel.Id == modelPersistence.IdFuel; })
                    //TODO
                    //Fuel = ModelPersistence.IdFuel
                    //Brand = ModelPersistence.IdBrand
                });
            }

            return models;
        }

    }
}