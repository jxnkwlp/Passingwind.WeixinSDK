using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class InterfaceSummaryRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class InterfaceSummaryResultModel : JsonResultModel
    {
        public IList<InterfaceSummaryResultItemModel> List { get; set; }
    }

    public class InterfaceSummaryResultItemModel
    {
        public string ref_date { get; set; }
        public int callback_count { get; set; }
        public int fail_count { get; set; }
        public int total_time_cost { get; set; }
        public int max_time_cost { get; set; }
    }
}
