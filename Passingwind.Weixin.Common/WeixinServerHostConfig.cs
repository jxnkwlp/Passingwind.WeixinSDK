using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin
{
    public class WeixinServerHostConfig
    {
        public const string DefaultWeixinApiHost = "https://api.weixin.qq.com";
        public const string DefaultOpenApiHost = "https://open.weixin.qq.com";

        public string DefaultApiHost { get; set; } = DefaultWeixinApiHost;

        public string OpenApiHost { get; set; } = DefaultOpenApiHost;

    }
}
