using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UserReadHourRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UserReadHourResultModel : JsonResultModel
    {
        public IList<UserReadHourResultItemModel> List { get; set; }
    }

    public class UserReadHourResultItemModel
    {
        public string Ref_date { get; set; }
        public string Ref_hour { get; set; }
        public int Int_page_read_user { get; set; }
        public int Int_page_read_count { get; set; }
        public int Ori_page_read_user { get; set; }
        public int Ori_page_read_count { get; set; }
        public int Share_user { get; set; }
        public int Share_count { get; set; }
        public int Add_to_fav_user { get; set; }
        public int Add_to_fav_count { get; set; }
    }
}
