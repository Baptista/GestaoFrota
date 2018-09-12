using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Users
{
    public class ServiceUsers : BaseService, IServiceUsers
    {
        public async Task<string> ChangeUserState(int id, bool state)
        {
            var url = GetUrl(UrlMethodType.ChangeUserState);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", $"{id}"));
            postData.Add(new KeyValuePair<string, string>("ativo", state ? "1" : "0"));

            var encodedContent = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, encodedContent);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> CreateUser(User user)
        {
            var url = GetUrl(UrlMethodType.AddUser);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("username", $"{user.Username}"));
            postData.Add(new KeyValuePair<string, string>("perfil", $"{user.Profile.Id}"));
            postData.Add(new KeyValuePair<string, string>("nome", $"{user.Name}"));

            var encodedContent = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, encodedContent);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetProfiles()
        {
            var url = GetUrl(UrlMethodType.GetProfiles);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetUser(int id)
        {
            var url = GetUrl(UrlMethodType.GetUsers) + $"/${id}";

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetUsers()
        {
            var url = GetUrl(UrlMethodType.GetUsers);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> ResetUserPassword(int id)
        {
            var url = GetUrl(UrlMethodType.ResetUserPassword) + $"/{id}";

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> UpdateUser(User user)
        {
            var url = GetUrl(UrlMethodType.UpdateUser);
            
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", $"{user.Id}"));
            postData.Add(new KeyValuePair<string, string>("username", $"{user.Username}"));
            postData.Add(new KeyValuePair<string, string>("perfil", $"{user.Profile.Id}"));
            postData.Add(new KeyValuePair<string, string>("nome", $"{user.Name}"));
            postData.Add(new KeyValuePair<string, string>("ativo", $"{(user.Active ? 1 : 0)}"));

            var encodedContent = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, encodedContent);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }
    }
}
