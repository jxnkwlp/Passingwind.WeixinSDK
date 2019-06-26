using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin
{
    public class JsonSerializerConfig
    {
        public static JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings()
        {
            Formatting = Formatting.None,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

    }
}
