using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    public class MapperUser
    {
        public static UserPersistence ToPersistence(User User)
        {
            var UserPersistence = new UserPersistence()
            {
                Id = User.Id,
                Active = (byte) (User.Active == true ? 1 : 0),
                Name = User.Name,
                Password = User.Password,
                Username = User.Username,
                IdProfile = User.Profile.Id
            };

            return UserPersistence;
        }

        public static List<UserPersistence> ToPersistence(List<User> Users)
        {
            var UsersPersistence = new List<UserPersistence>();

            foreach (var User in Users)
            {

                UsersPersistence.Add(new UserPersistence()
                {
                    Id = User.Id,
                    Active = (byte) (User.Active == true ? 1 : 0),
                    Name = User.Name,
                    Password = User.Password,
                    Username = User.Username,
                    IdProfile = User.Profile.Id
                });
            }

            return UsersPersistence;
        }

        public static User ToModel(UserPersistence UserPersistence)
        {
            var User = new User()
            {
                Id = UserPersistence.Id,
                Active = UserPersistence.Active == 1 ? true : false,
                Name = UserPersistence.Name,
                Password = UserPersistence.Password,
                Username = UserPersistence.Username,
                Profile = new Profile() {
                    Id = UserPersistence.IdProfile,
                    IsIncomplete = true
                }
            };

            return User;
        }

        public static List<User> ToModel(List<UserPersistence> UsersPersistence)
        {
            var Users = new List<User>();

            foreach (var UserPersistence in UsersPersistence)
            {
                Users.Add(new User()
                {
                    Id = UserPersistence.Id,
                    Active = UserPersistence.Active == 1 ? true : false,
                    Name = UserPersistence.Name,
                    Password = UserPersistence.Password,
                    Username = UserPersistence.Username,
                    Profile = new Profile() {
                        Id = UserPersistence.IdProfile,
                        IsIncomplete = true
                    }
                });
            }

            return Users;
        }

    }
}