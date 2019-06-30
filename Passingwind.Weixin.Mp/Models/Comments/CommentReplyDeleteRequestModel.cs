using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Comments
{
    public class CommentReplyDeleteRequestModel
    {
        public int Msg_Data_Id { get; set; }

        public int Index { get; set; }

        public int User_Comment_Id { get; set; }
    }
}
