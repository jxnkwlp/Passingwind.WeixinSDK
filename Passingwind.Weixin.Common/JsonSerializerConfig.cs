using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace Passingwind.Weixin
{
    public class JsonSerializerConfig
    {
        public static JsonSerializerSettings SerializerSettings = GetDefault();

        internal static JsonSerializerSettings GetDefault()
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                // ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ContractResolver = new LowercaseContractResolver(),
            };

            // 小写 Enum 值
            settings.Converters.Add(new LowercaseStringEnumConverter());

            return settings;
        }

    }

    internal class LowercaseStringEnumConverter : StringEnumConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                Enum @enum = (Enum)value;

                writer.WriteValue(@enum.ToString().ToLower());
            }
        }

    }

    internal class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        } 
    } 

}
