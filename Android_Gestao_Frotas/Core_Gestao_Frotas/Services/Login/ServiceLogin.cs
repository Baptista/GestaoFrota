﻿using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Login
{
    public class ServiceLogin : BaseService, IServiceLogin
    {
        public async Task<string> ExecuteLogin(string username, string password)
        {
            var url = GetUrl(UrlMethodType.GetLoginID);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("username", username));
            postData.Add(new KeyValuePair<string, string>("password", password));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> LoginUtilizador(string id)
        {
            var url = GetUrl(UrlMethodType.GetUsers) + $"/{id}";

            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetProfile(string id)
        {
            var url = GetUrl(UrlMethodType.GetProfiles) + $"/{id}";
            
            var content = await GetAsync(url);

            return content;
        }

        public async Task<string> GetUsers()
        {
            var url = GetUrl(UrlMethodType.GetUsers);
            
            var content = await GetAsync(url);

            return content;
        }
    }
}
