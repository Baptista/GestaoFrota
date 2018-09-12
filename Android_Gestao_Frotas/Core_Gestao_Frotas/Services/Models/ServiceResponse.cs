using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Models
{
    public class ServiceResponse
    {
        public const string StatusSuccess = "Success";
        public const string StatusFail = "Fail";

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        public bool Success
        {
            get
            {
                if (!string.IsNullOrEmpty(Status) && Status.Equals(StatusSuccess))
                    return true;
                else
                    return false;
            }
        }
    }
}
