using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.WeixinSDK.Models
{
    public class JsCode2SessionResponse : JsonErrorModel
    {
        public string OpenId { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        public string UnionId { get; set; }

    }
}
