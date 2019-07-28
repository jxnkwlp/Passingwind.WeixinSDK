using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.DataCube
{
    public class GetUserAnalysisRequestModel
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class GetUserAnalysisResultModel : JsonResultModel
    {
        public IList<GetUserAnalysisResultItemModel> List { get; set; }
    }

    public class GetUserAnalysisResultItemModel
    {
        public DateTime Ref_Date { get; set; }
        public int User_Source { get; set; }
        public int New_User { get; set; }
        public int Cancel_User { get; set; }
        public int Cumulate_User { get; set; }
    }
}
