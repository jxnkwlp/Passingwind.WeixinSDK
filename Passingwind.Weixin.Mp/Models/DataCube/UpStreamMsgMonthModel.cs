using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UpStreamMsgMonthRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UpStreamMsgMonthResultModel : JsonResultModel
    {
        public IList<UpStreamMsgMonthResultItemModel> List { get; set; }
    }

    public class UpStreamMsgMonthResultItemModel
    {
        public string Ref_date { get; set; }
        public int Msg_type { get; set; }
        public int Msg_user { get; set; }
        public int Msg_count { get; set; }
    }
}
