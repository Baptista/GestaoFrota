using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Configurations;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.NewPassword;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.NewPassword
{
    public class BusinessNewPassword : BaseBusiness, IBusinessNewPassword
    {
        public async Task<string> GetDefaultPassword()
        {
            string a = string.Empty;
            IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();
            var list = await repositoryConfiguration.GetAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Parameter == "password")
                {
                    a = list[i].Description;
                }
            }
            return a;
        }

        public async Task<bool> IsCurrentPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            var currentPassword = AllYouCanGet.CurrentUser.Password;
            if (password.Equals(currentPassword))
                return true;
            else
                return false;
        }

        public async Task<bool> TryChangePassword(string newPassword)
        {
            try
            {
                IServiceNewPassword serviceNewPassword = new ServiceNewPassword();
                IRepositoryUser repositoryUser = new RepositoryUser();

                var userJson = await serviceNewPassword.ChangeUserPassword(AllYouCanGet.CurrentUser, newPassword);
                var userPersistence = JsonConvert.DeserializeObject<List<UserPersistence>>(userJson);
                var result = await repositoryUser.Update(userPersistence[0]);

                AllYouCanGet.CurrentUser.Password = newPassword;

                return result != 0;
            }
            catch(Exception tryChangePasswordException)
            {
                Debug.WriteLine(tryChangePasswordException.StackTrace);
                return false;
            }
        }

        public async Task<bool> TryChangePasswordDefault(string newPassword)
        {
            try
            {
                IServiceNewPassword serviceNewPassword = new ServiceNewPassword();
                IRepositoryConfiguration repositoryConfiguration = new RepositoryConfiguration();

                var configurationJson = await serviceNewPassword.ChangeDefaultPassword(newPassword);
                var configurationPersistence = JsonConvert.DeserializeObject<List<ConfigurationPersistence>>(configurationJson);
                var result = await repositoryConfiguration.Update(configurationPersistence[0]);

                return true;
            }
            catch (Exception tryChangePasswordException)
            {
                Debug.WriteLine(tryChangePasswordException.StackTrace);
                return false;
            }
        }

        public async Task<bool> ValidateNewPassword(string newPassword, string confirmNewPassword)
        {
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
                return false;

            if (newPassword.Equals(confirmNewPassword))
                if (newPassword.Length >= 6 && newPassword.Length <= 15)
                    return true;
                else
                    return false;
            else
                return false;
        }
    }
}
