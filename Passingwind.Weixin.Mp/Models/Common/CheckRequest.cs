using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    public class CheckRequest
    {
        /// <summary>
        ///  执行的检测动作，允许的值：dns（做域名解析）、ping（做ping检测）、all（dns和ping都做）
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        ///  指定平台从某个运营商进行检测，允许的值：CHINANET（电信出口）、UNICOM（联通出口）、CAP（腾讯自建出口）、DEFAULT（根据ip来选择运营商）
        /// </summary>
        public string Check_Operator { get; set; }



        public class KnowActions
        {
            public const string ALL = "all";
            public const string DNS = "dns";
            public const string PING = "ping";
        }

        public class KnowCheckOperator
        {
            public const string DEFAULT = "DEFAULT";
            public const string CHINANET = "CHINANET";
            public const string UNICOM = "UNICOM";
            public const string CAP = "CAP";
        }
    }
}
