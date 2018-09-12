using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Login
{
    public class BusinessLoginMock : IBusinessLogin
    {
        public Task<bool> CheckIfPasswordIsDefault()
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadRequests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Login()
        {
            var users = new List<User>();

            for (var count = 0; count < 44; count++)
                users.Add(new User() {
                    Id = count,
                    Name = $"User {count}",
                    Username = $"UserName{count}",
                    Password = $"UserPassword{count}",
                    Active = true,
                    Profile = new Profile() {
                        Id = 2,
                        Description = $"user"} });

            return users;
        }

        public Task<bool> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUtilizador(string id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IBusinessLogin.Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
