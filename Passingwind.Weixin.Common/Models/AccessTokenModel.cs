using Newtonsoft.Json;
using System;

namespace Passingwind.Weixin.Models
{
    public class AccessTokenModel : JsonResultModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime ExpiresTime { get; set; }
    }
}
