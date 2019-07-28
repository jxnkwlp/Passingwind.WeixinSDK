using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UpStreamMsgDistMonthRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UpStreamMsgDistMonthResultModel : JsonResultModel
    {
        public IList<UpStreamMsgDistMonthResultItemModel> List { get; set; }
    }

    public class UpStreamMsgDistMonthResultItemModel
    {
        public string Ref_date { get; set; }
        public int Count_interval { get; set; }
        public int Msg_user { get; set; }
    }
}
