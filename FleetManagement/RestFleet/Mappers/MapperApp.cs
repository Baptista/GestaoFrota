using RestFleet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static RestFleet.Mappers.MapperJson;

namespace RestFleet.Mappers
{
    public class MapperApp
    {

        public static Marca MarcaAppToRest(BrandJson brandJson)
        {
            var marca = new Marca()
            {
                IdMarca = brandJson.Id,
                Descricao = brandJson.Description,
                Ativo = brandJson.Active
            };
            return marca;
        }

        public static Modelo ModeloAppToRest(ModelJson modelJson)
        {
            var modelo = new Modelo()
            {
                IdModelo = modelJson.Id,
                Descricao = modelJson.Description,
                IdCombustivel = modelJson.Fuel.Id,
                IdMarca = modelJson.Brand.Id,
                Ativo = modelJson.Active
            };
            return modelo;
        }

        public static Tipologia TipologiaAppToRest(TypologyJson typologyJson)
        {
            var tipologia = new Tipologia()
            {
                IdTipologia = typologyJson.Id,
                Descricao = typologyJson.Description,
                Ativo = typologyJson.Active
            };
            return tipologia;
        }

        public static Veiculo VeiculoAppToRest(VehicleJson vehicleJson)
        {
            var veiculo = new Veiculo()
            {
                IdVeiculo = vehicleJson.Id,
                IdModelo = vehicleJson.Model.Id,
                IdTipologia = vehicleJson.Typology.Id,
                IdUtilizador = vehicleJson.User.Id,
                Matricula = vehicleJson.LicensePlate,
                Ativo = vehicleJson.Active,
                Disponivel = vehicleJson.Available,
                KmsIniciais = decimal.Parse(vehicleJson.StartKms.ToString()),
                KmsContrato = decimal.Parse(vehicleJson.ContractKms.ToString()),
                Danos_Veiculo = new List<Danos_Veiculo>(),
                Pedido_Marcacao_Historico = new List<Pedido_Marcacao_Historico>()
            };
            return veiculo;
        }

        public static Utilizador UtilizadorAppToRest(UserJson userJson)
        {
            var utilizador = new Utilizador()
            {
                IdUtilizador = userJson.Id,
                Nome = userJson.Name,
                Username = userJson.Username,
                Password = userJson.Password,
                Ativo = userJson.Active,
                IdPerfil = userJson.Profile.Id
            };
            return utilizador;
        }

    }

}