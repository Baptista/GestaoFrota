using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var url = GetUrl(UrlMethodType.InsertModel);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            var result = await PostAsync(url, postData);

            return result;
        }

        public async Task<string> UpdateModel(Model model)
        {
            var url = GetUrl(UrlMethodType.UpdateModel);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmodelo", model.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            var result = await PostAsync(url, postData);

            return result;
        }
    }
}
