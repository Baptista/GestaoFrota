using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.VehicleInfo
{
    public class ServiceVehicleInfo : BaseService, IServiceVehicleInfo
    {
        public async Task<string> ChangeVehicleState(Vehicle vehicle)
        {
            var url = GetUrl(UrlMethodType.ChangeVehicleState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idveiculo", vehicle.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", vehicle.Active ? "0" : "1"));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> NewVehicle(Vehicle vehicle)
        {
            var url = GetUrl(UrlMethodType.AddVehicle);
            
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmodelo", $"{vehicle.Model.Id}"));
            postData.Add(new KeyValuePair<string, string>("idtipologia", $"{vehicle.Typology.Id}"));
            postData.Add(new KeyValuePair<string, string>("idutilizador", vehicle.User.Id == BaseModel.Null ? "NULL" : $"{vehicle.User.Id}"));
            postData.Add(new KeyValuePair<string, string>("Matricula", $"{vehicle.LicensePlate}"));
            postData.Add(new KeyValuePair<string, string>("kmsiniciais", $"{vehicle.StartKms}"));
            postData.Add(new KeyValuePair<string, string>("kmscontrato", $"{vehicle.ContractKms}"));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> UpdateVehicle(Vehicle vehicle)
        {
            var url = GetUrl(UrlMethodType.AddVehicle);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idveiculo", $"{vehicle.Id}"));
            postData.Add(new KeyValuePair<string, string>("idmodelo", $"{vehicle.Model.Id}"));
            postData.Add(new KeyValuePair<string, string>("idtipologia", $"{vehicle.Typology.Id}"));
            postData.Add(new KeyValuePair<string, string>("idutilizador", vehicle.User.Id == BaseModel.Null ? "NULL" : $"{vehicle.User.Id}"));
            postData.Add(new KeyValuePair<string, string>("Matricula", $"{vehicle.LicensePlate}"));
            postData.Add(new KeyValuePair<string, string>("kmsiniciais", $"{vehicle.StartKms}"));
            postData.Add(new KeyValuePair<string, string>("kmscontrato", $"{vehicle.ContractKms}"));

            var content = await PostAsync(url, postData);

            return content;
        }
    }
}
