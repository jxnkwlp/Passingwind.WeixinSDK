using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UserShareHourRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UserShareHourResultModel : JsonResultModel
    {
        public IList<UserShareHourResultItemModel> List { get; set; }
    }

    public class UserShareHourResultItemModel
    {
        public string Ref_date { get; set; }
        public string Ref_Hour { get; set; }
        public int Share_scene { get; set; }
        public int Share_count { get; set; }
        public int Share_user { get; set; }
    }
}
