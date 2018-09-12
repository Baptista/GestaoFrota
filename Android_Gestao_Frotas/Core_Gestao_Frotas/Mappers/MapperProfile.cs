using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperProfile
    {

        public static ProfilePersistence ToPersistence(Profile Profile)
        {
            var ProfilePersistence = new ProfilePersistence()
            {
                Id = Profile.Id,
                Description = Profile.Description,
                Active = (byte)(Profile.Active == true ? 1 : 0)
                //TODO
                //Permissions = ProfilePersistence.permission??
            };

            return ProfilePersistence;
        }

        public static List<ProfilePersistence> ToPersistence(List<Profile> Profiles)
        {
            var ProfilesPersistence = new List<ProfilePersistence>();

            foreach (var Profile in Profiles)
            {
                ProfilesPersistence.Add(new ProfilePersistence()
                {
                    Id = Profile.Id,
                    Description = Profile.Description,
                    Active = (byte)(Profile.Active == true ? 1 : 0)
                    //TODO
                    //Permissions = ProfilePersistence.permission??
                });
            }

            return ProfilesPersistence;
        }

        public static Profile ToModel(ProfilePersistence ProfilePersistence)
        {
            var Profile = new Profile()
            {
                Id = ProfilePersistence.Id,
                Description = ProfilePersistence.Description,
                Active = ProfilePersistence.Active == 1 ? true : false
                //TODO
                //Permissions = ProfilePersistence.permission??
            };

            return Profile;
        }

        public static List<Profile> ToModel(List<ProfilePersistence> ProfilesPersistence)
        {
            var Profiles = new List<Profile>();

            foreach (var ProfilePersistence in ProfilesPersistence)
            {
                Profiles.Add(new Profile()
                {
                    Id = ProfilePersistence.Id,
                    Description = ProfilePersistence.Description,
                    Active = ProfilePersistence.Active == 1 ? true : false
                    //TODO
                    //Permissions = ProfilePersistence.permission??
                });
            }

            return Profiles;
        }

    }
}
