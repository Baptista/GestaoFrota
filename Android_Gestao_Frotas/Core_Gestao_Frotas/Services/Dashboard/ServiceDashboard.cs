using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core_Gestao_Frotas.Services.Dashboard
{
    public class ServiceDashboard : BaseService, IServiceDashboard
    {
        public async Task<string> GetBrands()
        {
            //var url = GetUrl(UrlMethodType.GetBrands);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebBrands);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetDamagesVehicle()
        {
            //var url = GetUrl(UrlMethodType.GetDamageVehicle);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebDamageVehicle);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetDamageVehicleDocuments()
        {
            //var url = GetUrl(UrlMethodType.GetDamageVehicleDocument);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebDamageVehicleDocument);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetFuels()
        {
            //var url = GetUrl(UrlMethodType.GetFuels);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebFuels);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetModels()
        {
            //var url = GetUrl(UrlMethodType.GetModels);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebModels);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetTypologies()
        {
            //var url = GetUrl(UrlMethodType.GetTypologies);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebTypologys);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetVehicles()
        {
            //var url = GetUrl(UrlMethodType.GetVehicles);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebVehicles);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetVehiclesHistory()
        {
            //var url = GetUrl(UrlMethodType.GetVehicleHistory);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebVehicleHistory);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsActiveAll()
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsActive);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsForApproval()
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsForApproval);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsUnavailable()
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsUnavailable);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsCurso(User user)
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsCurso);
            url = url + "?id=" + user.Id;
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsActiveUser(User user)
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsActive);
            url = url + "?id=" + user.Id;
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestsActiveUserVehicle(User user, Vehicle vehicle)
        {
            var url = GetUrl(UrlMethodType.GetWebRequestsActive);
            url = url + "?id=" + user.Id + "&idveiculo=" + vehicle.Id;
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> ChangeUserPassword(User user)
        {
            var url = GetUrl(UrlMethodType.ChangeUserPassword);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", user.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> GetRequestJustificationTypes()
        {
            //var url = GetUrl(UrlMethodType.GetRequestJustificationTypes);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebRequestJustificationTypes);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestStates()
        {
            //var url = GetUrl(UrlMethodType.GetRequestStates);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebRequestStates);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequests()
        {
            //var url = GetUrl(UrlMethodType.GetRequests);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebRequests);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestJustifications()
        {
            //var url = GetUrl(UrlMethodType.GetRequestJustifications);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebRequestJustifications);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetRequestHistories()
        {
            //var url = GetUrl(UrlMethodType.GetRequestHistories);
            //var content = await GetAsync(url);
            var url = GetUrl(UrlMethodType.GetWebRequestHistories);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> ApproveRequest(RequestHistory requesthistory)
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

        public async Task<string> CancelRequest(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.CancelRequest);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacaohistorico", requesthistory.Id.ToString()));

            var content = await PostAsync(url,  postData);

            return content;
        }

        public async Task<string> AddJustification(RequestJustification requestJustification, int conflitID)
        {
            var url = GetUrl(UrlMethodType.AddJustification);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("IdTipoJustificacaoPedido", requestJustification.RequestJustificationType.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("IdPedidoMarcacao", requestJustification.Request.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("Justificacao", requestJustification.Justification));
            postData.Add(new KeyValuePair<string, string>("IdPedidoMarcacaoConflito", conflitID.ToString()));

            var content = await PostAsync(url, postData);

            return content;
        }

    }
}
