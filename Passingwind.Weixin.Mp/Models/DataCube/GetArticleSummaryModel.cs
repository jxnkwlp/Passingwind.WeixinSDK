using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class ArticleSummaryRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class ArticleSummaryResultModel : JsonResultModel
    {
        public IList<ArticleSummaryResultItemModel> List { get; set; }
    }

    public class ArticleSummaryResultItemModel
    {
        public string Ref_Date { get; set; }
        public string Msgid { get; set; }
        public string Title { get; set; }
        public int Int_Page_Read_user { get; set; }
        public int Int_Page_Read_Count { get; set; }
        public int Ori_Page_Read_User { get; set; }
        public int Ori_Page_Read_Count { get; set; }
        public int Share_User { get; set; }
        public int Share_Count { get; set; }
        public int Add_To_Fav_User { get; set; }
        public int Add_To_Fav_Count { get; set; }
    }
}
