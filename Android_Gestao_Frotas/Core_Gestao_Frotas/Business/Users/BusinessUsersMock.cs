using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Users
{
    public class BusinessUsersMock : IBusinessUsers
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            await Task.Delay(2000);
            var users = new List<User>();

            for (var count = 0; count < 44; count++)
                users.Add(new User()
                {
                    Id = count,
                    Name = $"User {count}",
                    Username = $"UserName{count}",
                    Password = $"UserPassword{count}",
                    Active = true,
                    Profile = new Profile()
                    {
                        Id = 2,
                        Description = $"user",
                    }
                });

            return users;
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var profiles = new List<Profile>();

            profiles.Add(new Profile()
            {
                Id = 1,
                Description = "Administrador"
            });
            profiles.Add(new Profile()
            {
                Id = 2,
                Description = "Validador"
            });
            profiles.Add(new Profile()
            {
                Id = 3,
                Description = "Utilizador"
            });

            return profiles;
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetUserPassword(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserState(int id, bool state)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserProfileStatus(User user)
        {
            throw new NotImplementedException();
        }
    }
}
