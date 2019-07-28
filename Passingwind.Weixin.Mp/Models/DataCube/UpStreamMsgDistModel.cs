using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UpStreamMsgDistRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UpStreamMsgDistResultModel : JsonResultModel
    {
        public IList<UpStreamMsgDistResultItemModel> List { get; set; }
    }

    public class UpStreamMsgDistResultItemModel
    {
        public string Ref_date { get; set; }
        public int Count_interval { get; set; }
        public int Msg_user { get; set; }
    }
}
