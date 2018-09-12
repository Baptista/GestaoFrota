using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Requests
{
    public class ServiceRequests : BaseService, IServiceRequests
    {
        public async Task<string> AddDano(DamageVehicle damageVehicle)
        {
            var url = GetUrl(UrlMethodType.adddano);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", damageVehicle.RequestHistory.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("descricao", damageVehicle.Description));
            postData.Add(new KeyValuePair<string, string>("idveiculo", damageVehicle.Vehicle.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AddDanoComprovativo(DamageVehicleDocument damageVehicleDocument)
        {
            var url = GetUrl(UrlMethodType.adddanocomprovativo);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iddanosveiculo", damageVehicleDocument.DamageVehicle.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("documento", damageVehicleDocument.Document.ToString()));
            postData.Add(new KeyValuePair<string, string>("formatodocumento", damageVehicleDocument.DocumentFormat));
            postData.Add(new KeyValuePair<string, string>("nomedocumento", damageVehicleDocument.DocumentName));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AddRequestVehicle(Request request)
        {
            var url = GetUrl(UrlMethodType.addpedido);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", request.User.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("data", request.RequestDate.ToString("yyyy-MM-dd HH:mm")));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AddRequestVehicleHistory(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.addpedidohistorico);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacao", requesthistory.Request.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("idveiculo", requesthistory.Vehicle.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("idutilizador", requesthistory.User.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("datainicio", requesthistory.StartDate.ToString("yyyy-MM-dd HH:mm")));
            postData.Add(new KeyValuePair<string, string>("datafim", requesthistory.EndDate.ToString("yyyy-MM-dd HH:mm")));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AddVeiculoHistorico(VehicleHistory vehicleHistory)
        {
            var url = GetUrl(UrlMethodType.addveiculohistorico);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", vehicleHistory.RequestHistory.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("kms", vehicleHistory.Kms.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AprovaPedido(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.AprovaPedido);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", requesthistory.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> GetVeiculosDisponiveis(String datainicio, String Datafim)
        {
            var url = GetUrl(UrlMethodType.GetAvailableVehicles);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("datainicio", datainicio));
            postData.Add(new KeyValuePair<string, string>("datafim", Datafim));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> TerminaPedido(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.terminapedido);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", requesthistory.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }



    }
}
