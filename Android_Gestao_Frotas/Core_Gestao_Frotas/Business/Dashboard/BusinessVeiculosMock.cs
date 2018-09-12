using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Dashboard
{
    public class BusinessVeiculosMock : IBusinessVeiculos
    {
        public async Task<IEnumerable<Brand>> GetMarcas()
        {
            var marcas = new List<Brand>();

            marcas.Add(new Brand()
            {
                Id = 1,
                Description = "Volvo",
                Active = true
                });

            return marcas;
        }

        public async Task<IEnumerable<Model>> GetModelos()
        {
            var Modelos = new List<Model>();

            Modelos.Add(new Model()
            {
                Id = 1,
                Description = "meme",
                Active = true,
                Brand = new Brand()
                {
                    Id = 1,
                    Description = "Volvo",
                },
                Fuel = new Fuel()
                {
                    Id = 1,
                    Description = "Gasoleo",
                }
            });

            return Modelos;
        }

        public async Task<IEnumerable<Typology>> GetTipologias()
        {
            var Tipologias = new List<Typology>();

            Tipologias.Add(new Typology()
            {
                Id = 1,
                Description = "Modelo A",
                Active = true
            });

            return Tipologias;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var Veiculos = new List<Vehicle>();

            Veiculos.Add(new Vehicle()
            {
                Id = 1,
                Model = new Model()
                {
                    Id = 1,
                    Brand = new Brand()
                    {
                        Id = 1,
                        Description = "Volvo",
                        Active = true
                    },
                    Fuel = new Fuel()
                    {
                        Id = 1,
                        Description = "Diesel"
                    },
                    Description = "meme",
                    Active = true
                },
                Typology = new Typology()
                {
                    Id = 1,
                    Description = "Modelo A",
                },
                User = new User()
                {
                    Id = 1,
                    Username = "cenas",
                    Password = "coisas",
                    Name = "Tiago",
                    Profile = new Profile()
                    {
                        Id = 1,
                        Description = "Administrador",
                    },
                    Active = true
                },
                LicensePlate = "32-LE-12",
                StartKms = 1000,
                ContractKms = 2000,
                Active = true,
                Available = true
            });

            return Veiculos;
        }

        public async Task<IEnumerable<Fuel>> GetCombustiveis()
        {
            var Combustiveis = new List<Fuel>();

            Combustiveis.Add(new Fuel()
            {
                Id = 1,
                Description = "Diesel"
            });

            return Combustiveis;
        }

        public Task<bool> InsertMarca(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertModel(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertTypology(Typology typology)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMarca(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateModel(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTypology(Typology typology)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAllModel(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeMarcaState(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeModelState(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeTypologyState(Typology typology)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeVehicleState(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> GetBrands(bool usePersistence = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model>> GetModels(bool usePersistence = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Typology>> GetTypologies(bool usePersistence = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehicles(bool usePersistence = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fuel>> GetFuels(bool usePersistence = false)
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
