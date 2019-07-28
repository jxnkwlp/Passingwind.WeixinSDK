using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    public class UserBlackListResultModel : JsonResultModel
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public OpenIdData Data { get; set; }
        public string Next_Openid { get; set; }

        public class OpenIdData
        {
            public string[] Openid { get; set; }
        }
    }
}
