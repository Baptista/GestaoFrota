using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Damage
{
    public class ServiceDamage : BaseService, IServiceDamage
    {
        public async Task<string> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            var url = GetUrl(UrlMethodType.addveiculohistorico);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", vehicleHistory.RequestHistory.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("kms", vehicleHistory.Kms.ToString()));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> TerminaPedido(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.terminapedido);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", requesthistory.Id.ToString()));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> AddDano(DamageVehicle damageVehicle)
        {
            var url = GetUrl(UrlMethodType.adddano);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", damageVehicle.RequestHistory.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("descricao", damageVehicle.Description));
            postData.Add(new KeyValuePair<string, string>("idveiculo", damageVehicle.Vehicle.Id.ToString()));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            var url = GetUrl(UrlMethodType.adddanocomprovativo);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iddanosveiculo", damageVehicleDocument.DamageVehicle.Id.ToString()));

            //var document = JsonConvert.SerializeObject(damageVehicleDocument.Document);
            var document = Convert.ToBase64String(damageVehicleDocument.Document, 0, damageVehicleDocument.Document.Length);
            //var document = Encoding.UTF8.GetString(damageVehicleDocument.Document, 0, damageVehicleDocument.Document.Length);
            
            //damageVehicleDocument.Document

            postData.Add(new KeyValuePair<string, string>("documento", document));
            postData.Add(new KeyValuePair<string, string>("formatodocumento", damageVehicleDocument.DocumentFormat));
            postData.Add(new KeyValuePair<string, string>("nomedocumento", damageVehicleDocument.DocumentName));

            var content = await PostAsync(url, postData);

            return content;
        }
    }
}
