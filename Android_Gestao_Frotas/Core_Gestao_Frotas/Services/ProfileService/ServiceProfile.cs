using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.ProfileService
{
    public class ServiceProfile : BaseService, IServiceProfile
    {
        public async Task<string> AddProfile(Profile profile)
        {
            var url = GetUrl(UrlMethodType.addprofile);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("descricao", profile.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> AddProfilePermission(int idprofile, int idpermissao, int ativo)
        {
            var url = GetUrl(UrlMethodType.addprofilepermission);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idperfil", idprofile.ToString()));
            postData.Add(new KeyValuePair<string, string>("idpermissao", idpermissao.ToString()));
            postData.Add(new KeyValuePair<string, string>("Ativo", ativo.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> ChangeProfileState(Profile profile)
        {
            var url = GetUrl(UrlMethodType.stateprofile);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idprofile", profile.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("ativo", profile.Active ? "0" : "1"));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<string> CheckUserStatusProfile(Profile profile)
        {
            var url = GetUrl(UrlMethodType.userprofilexists);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idprofile", profile.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }

        public async Task<bool> DeletePermissions(Profile profile)
        {
            var url = GetUrl(UrlMethodType.deletepermissions);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idperfil", profile.Id.ToString()));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            //var content2 = await result.Content.ReadAsStringAsync();

            return true;
        }

        public async Task<string> UpdateProfile(Profile profile)
        {
            var url = GetUrl(UrlMethodType.updateprofile);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("idprofile", profile.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("descricao", profile.Description));

            var content = new FormUrlEncodedContent(postData);

            var client = new HttpClient();

            var result = await client.PostAsync(url, content);
            var content2 = await result.Content.ReadAsStringAsync();

            return content2;
        }
    }
}
