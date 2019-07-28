using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UpStreamMsgDistWeekRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UpStreamMsgDistWeekResultModel : JsonResultModel
    {
        public IList<UpStreamMsgDistWeekResultItemModel> List { get; set; }
    }

    public class UpStreamMsgDistWeekResultItemModel
    {
        public string Ref_date { get; set; }
        public int Count_interval { get; set; }
        public int Msg_user { get; set; }
    }
}
