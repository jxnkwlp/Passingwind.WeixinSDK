using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Common
{
    public class GenerateShortUrlRequestModel
    {
        public string Action { get; set; } = "long2short";

        public string Long_Url { get; set; }
    }
}
