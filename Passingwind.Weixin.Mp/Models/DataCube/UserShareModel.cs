using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UserShareRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UserShareResultModel : JsonResultModel
    {
        public IList<UserShareResultItemModel> List { get; set; }
    }

    public class UserShareResultItemModel
    {
        public string Ref_date { get; set; }
        public int Share_scene { get; set; }
        public int Share_count { get; set; }
        public int Share_user { get; set; }
    }
}
