using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Common
{
    public static class Extensions
    {
        public static T ToJsonModel<T>(this string jsonText)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
        }

        public static T ToJsonResultModel<T>(this string jsonText) where T : JsonResultModel
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
            result.Raw = jsonText;
            return result;
        }
    }
}
