using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Comments
{
    public class CommentListResultModel : JsonResultModel
    {
        public int Total { get; set; }

        public IList<CommentItemModel> Comment { get; set; }

    }

}
