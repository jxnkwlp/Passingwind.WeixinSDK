using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    /// <summary>
    ///  获取微信服务器IP地址 
    /// </summary>
    public class CallbackIpJsonReturnModel : JsonResultModel
    {
        public string[] Ip_List { get; set; }
    }
}
