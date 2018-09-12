using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Vehicles
{
    public class ServiceVehicle : BaseService, IServiceVehicle
    {
        public async Task<String> GetBrands()
        {
            var url = GetUrl(UrlMethodType.GetBrands);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<String> GetFuels()
        {
            var url = GetUrl(UrlMethodType.GetFuels);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<String> GetModels()
        {
            var url = GetUrl(UrlMethodType.GetModels);
            var content = await GetAsync(url);

            return content;
        }

        public async Task<String> GetTypologys()
        {
            var url = GetUrl(UrlMethodType.GetTypologies);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<String> GetVehicles()
        {
            var url = GetUrl(UrlMethodType.GetVehicles);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> InsertBrand(Brand brand)
        {
            var url = GetUrl(UrlMethodType.InsertBrand);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("marca", brand.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> InsertModel(Model model)
        {
            var url = GetUrl(UrlMethodType.InsertModel);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> InsertTypology(Typology typology)
        {
            var url = GetUrl(UrlMethodType.InsertTypology);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("tipologia", typology.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> UpdateBrand(Brand brand)
        {
            var url = GetUrl(UrlMethodType.UpdateBrand);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmarca", brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("marca", brand.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> UpdateModel(Model model)
        {
            var url = GetUrl(UrlMethodType.UpdateModel);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmodelo", model.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("modelo", model.Description));
            postData.Add(new KeyValuePair<string, string>("marca", model.Brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("combustivel", model.Fuel.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> UpdateTypology(Typology typology)
        {
            var url = GetUrl(UrlMethodType.UpdateTypology);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idtipologia", typology.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("tipologia", typology.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> ChangeBrandState(Brand brand)
        {
            var url = GetUrl(UrlMethodType.ChangeBrandState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmarca", brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", brand.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> ChangeModelState(Model model)
        {
            var url = GetUrl(UrlMethodType.ChangeModelState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmodelo", model.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", model.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> ChangeTypologyState(Typology typology)
        {
            var url = GetUrl(UrlMethodType.ChangeTypologyState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idtipologia", typology.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", typology.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> UpdateAllModel(Brand brand)
        {
            var url = GetUrl(UrlMethodType.ChangeAllModelsState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idmarca", brand.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", brand.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> ChangeVehicleState(Vehicle vehicle)
        {
            var url = GetUrl(UrlMethodType.ChangeVehicleState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idveiculo", vehicle.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", vehicle.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }
    }
}
