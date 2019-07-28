using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UserReadRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UserReadResultModel : JsonResultModel
    {
        public IList<UserReadResultItemModel> List { get; set; }
    }

    public class UserReadResultItemModel
    {
        public string Ref_date { get; set; }
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
