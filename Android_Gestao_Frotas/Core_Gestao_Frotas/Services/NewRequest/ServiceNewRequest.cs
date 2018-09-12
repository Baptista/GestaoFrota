using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.NewRequest
{
    public class ServiceNewRequest : BaseService, IServiceNewRequest
    {
        public async Task<string> ExisteSobreposicao(int IdUtilizador, DateTime startDate, DateTime endDate)
        {
            var url = GetUrl(UrlMethodType.ExisteSobreposicao);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idutilizador", IdUtilizador.ToString()));
            postData.Add(new KeyValuePair<string, string>("datainicio", startDate.ToString("yyyy-MM-dd HH:mm")));
            postData.Add(new KeyValuePair<string, string>("datafim", endDate.ToString("yyyy-MM-dd HH:mm")));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> NewRequest(Request request)
        {
            var url = GetUrl(UrlMethodType.addpedido);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", request.User.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("data", request.RequestDate.ToString("yyyy-MM-dd HH:mm")));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> NewRequestHistory(RequestHistory requesthistory)
        {
            var url = GetUrl(UrlMethodType.addpedidohistorico);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idpedidomarcacao", requesthistory.Request.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("idveiculo", requesthistory.Vehicle.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("idutilizador", requesthistory.User.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("datainicio", requesthistory.StartDate.ToString("yyyy-MM-dd HH:mm:ss")));
            postData.Add(new KeyValuePair<string, string>("datafim", requesthistory.EndDate.ToString("yyyy-MM-dd HH:mm:ss")));

            var content = await PostAsync(url, postData);

            return content;
        }
    }
}
