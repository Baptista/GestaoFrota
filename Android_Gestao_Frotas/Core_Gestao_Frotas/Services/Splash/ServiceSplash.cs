using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.IO;
using Core_Gestao_Frotas.Services.Models;

namespace Core_Gestao_Frotas.Services.Splash
{
    public class ServiceSplash : BaseService, IServiceSplash
    {
        public async Task<string> GetConfigutations()
        {
            //var url = GetUrl(UrlMethodType.GetConfigurations);
            var url = GetUrl(UrlMethodType.GetWebConfigurations);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetPermissions()
        {
            //var url = GetUrl(UrlMethodType.GetPermissions);
            var url = GetUrl(UrlMethodType.GetWebPermissions);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetProfilePermissions()
        {
            //var url = GetUrl(UrlMethodType.GetProfilePermissions);
            var url = GetUrl(UrlMethodType.GetWebProfilePermissions);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetProfiles()
        {
            //var url = GetUrl(UrlMethodType.GetProfiles);
            var url = GetUrl(UrlMethodType.GetWebProfiles);

            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }
    }
}
