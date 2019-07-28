using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    public class UserListResultModel : JsonResultModel
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public Data2 Data { get; set; }
        public string Next_Openid { get; set; }

        public class Data2
        {
            public string[] Openid { get; set; }
        }

    }
}
