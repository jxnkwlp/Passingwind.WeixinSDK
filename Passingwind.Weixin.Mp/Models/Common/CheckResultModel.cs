using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    /// <summary>
    ///  网络检测 结果
    /// </summary>
    public class CheckResultModel : JsonResultModel
    {
        public Dn[] Dns { get; set; }
        public Pg[] Ping { get; set; }

        public class Dn
        {
            public string Ip { get; set; }
            public string real_operator { get; set; }
        }

        public class Pg
        {
            public string Ip { get; set; }
            public string From_operator { get; set; }
            public string Package_loss { get; set; }
            public string Time { get; set; }
        }

    }
}
