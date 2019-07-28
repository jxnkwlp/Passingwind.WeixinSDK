using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class ArticleTotalRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class ArticleTotalResultModel : JsonResultModel
    {
        public IList<ArticleTotalResultItemModel> List { get; set; }
    }

    public class ArticleTotalResultItemModel
    {
        public string Ref_Date { get; set; }
        public string Msgid { get; set; }
        public string Title { get; set; }
        public DetailModel[] Details { get; set; }

        public class DetailModel
        {
            public string Stat_date { get; set; }
            public int Target_user { get; set; }
            public int Int_page_read_user { get; set; }
            public int Int_page_read_count { get; set; }
            public int Ori_page_read_user { get; set; }
            public int Ori_page_read_count { get; set; }
            public int Share_user { get; set; }
            public int Share_count { get; set; }
            public int Add_to_fav_user { get; set; }
            public int Add_to_fav_count { get; set; }
            public int Int_page_from_session_read_user { get; set; }
            public int Int_page_from_session_read_count { get; set; }
            public int Int_page_from_hist_msg_read_user { get; set; }
            public int Int_page_from_hist_msg_read_count { get; set; }
            public int Int_page_from_feed_read_user { get; set; }
            public int Int_page_from_feed_read_count { get; set; }
            public int Int_page_from_friends_read_user { get; set; }
            public int Int_page_from_friends_read_count { get; set; }
            public int Int_page_from_other_read_user { get; set; }
            public int Int_page_from_other_read_count { get; set; }
            public int Feed_share_from_session_user { get; set; }
            public int Feed_share_from_session_cnt { get; set; }
            public int Feed_share_from_feed_user { get; set; }
            public int Feed_share_from_feed_cnt { get; set; }
            public int Feed_share_from_other_user { get; set; }
            public int Feed_share_from_other_cnt { get; set; }
        }

    }
}
