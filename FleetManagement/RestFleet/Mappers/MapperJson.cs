using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFleet.Mappers
{
    public static class MapperJson
    {

        public static T FromJson<T>(this string str)
        where T : class
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public class LoginJson
        {
            public string User { get; set; }

            public string Password { get; set; }
        }

        public class BrandJson
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }
        }

        public class ModelJson
        {
            public int Id { get; set; }

            public BrandJson Brand { get; set; }

            public FuelJson Fuel { get; set; }

            public string Description { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }
        }

        public class FuelJson
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool IsIncomplete { get; set; }
        }

        public class TypologyJson
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }
        }

        public class VehicleJson
        {
            public int Id { get; set; }

            public ModelJson Model { get; set; }

            public TypologyJson Typology { get; set; }

            public UserJson User { get; set; }

            public string LicensePlate { get; set; }

            public float StartKms { get; set; }

            public float ContractKms { get; set; }

            public bool Available { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }

        }

        public class UserJson
        {
            public int Id { get; set; }

            public ProfileJson Profile { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string Name { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }
        }

        public class ProfileJson
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool Active { get; set; }

            public bool IsIncomplete { get; set; }
        }

    }
}