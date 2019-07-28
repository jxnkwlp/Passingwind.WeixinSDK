using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class UpStreamMsgRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class UpStreamMsgResultModel : JsonResultModel
    {
        public IList<UpStreamMsgResultItemModel> List { get; set; }
    }

    public class UpStreamMsgResultItemModel
    {
        public string Ref_date { get; set; }
        public int Msg_type { get; set; }
        public int Msg_user { get; set; }
        public int Msg_count { get; set; }
    }
}
