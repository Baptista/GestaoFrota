using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.NewPassword
{
    public class ServiceNewPassword : BaseService, IServiceNewPassword
    {
        public async Task<string> ChangeDefaultPassword(string newPassword)
        {
            var url = GetUrl(UrlMethodType.ChangeDefaultPassword);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("defaultpassword", newPassword));

            var content = await PostAsync(url, postData);

            return content;
        }

        public async Task<string> ChangeUserPassword(User user, string newPassword)
        {
            var url = GetUrl(UrlMethodType.ChangeUserPassword);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("iduser", user.Id.ToString()));
            postData.Add(new KeyValuePair<string, string>("password", newPassword));

            var content = await PostAsync(url, postData);

            return content;
        }
    }
}
