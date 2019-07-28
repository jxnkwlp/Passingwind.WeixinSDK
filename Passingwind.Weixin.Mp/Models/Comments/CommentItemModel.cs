using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Comments
{
    public class CommentItemModel
    {
        public string User_Comment_Id { get; set; }
        public string OpenId { get; set; }
        public long Create_Time { get; set; }
        public string Content { get; set; }
        public int Comment_Type { get; set; }

        public class CommentReplyModel
        {
            public string Content { get; set; }
            public long Create_Time { get; set; }
        }
    }

}
