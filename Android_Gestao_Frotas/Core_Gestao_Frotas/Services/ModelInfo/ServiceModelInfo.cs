using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.ModelInfo
{
    public class ServiceModelInfo : BaseService, IServiceModelInfo
    {
        public async Task<string> ChangeModelState(Model model)
        {
            var url = GetUrl(UrlMethodType.ChangeModelState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmodelo", model.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", model.Active ? "0" : "1"));

            var result = await PostAsync(url, postData);

            return result;
        }

        public async Task<string> NewModel(Model model)
        {
            //var url = GetUrl(UrlMethodType.InsertWebModel);

            ////var postData = new List<KeyValuePair<string, string>>();
            ////postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            ////postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            ////postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            //var result = await PostAsync(url, postData);

            //return result;
            model.Active = true;

            var url = GetUrl(UrlMethodType.InsertWebModel);


            var jsontxt = MapperWeb.ToJson(model);

            var client = new HttpClient();
            var content = await PostAsyncWeb(url, jsontxt);

            return content;
        }

        public async Task<string> UpdateModel(Model model)
        {
            //var url = GetUrl(UrlMethodType.UpdateModel);

            //var postData = new List<KeyValuePair<string, string>>();
            //postData.Add(new KeyValuePair<string, string>("idmodelo", model.Id.ToString()));
            //postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            //postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            //postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            //var result = await PostAsync(url, postData);

            //return result;
            var url = GetUrl(UrlMethodType.UpdateWebModel);


            var jsontxt = MapperWeb.ToJson(model);

            var client = new HttpClient();
            var content = await PostAsyncWeb(url, jsontxt);

            return content;
        }
    }
}
