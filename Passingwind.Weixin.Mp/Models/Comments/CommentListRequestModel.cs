using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Comments
{
    public class CommentListRequestModel
    {
        public int Msg_Data_Id { get; set; }
        public int Index { get; set; }
        public int Begin { get; set; }
        public int Count { get; set; }
        public int Type { get; set; }

    }
}
