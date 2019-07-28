using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    /// <summary>
    ///  用户基本信息（包括UnionID机制）
    /// </summary>
    public class UserInfoResultModel : JsonResultModel
    {
        public int Subscribe { get; set; }
        public string Openid { get; set; }
        public string Nickname { get; set; }
        public int Sex { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Headimgurl { get; set; }
        public int Subscribe_time { get; set; }
        public string Unionid { get; set; }
        public string Remark { get; set; }
        public int Groupid { get; set; }
        public string[] Tagid_List { get; set; }
        public string Subscribe_Scene { get; set; }
        public string Qr_Scene { get; set; }
        public string Qr_Scene_Str { get; set; }
    }
}
