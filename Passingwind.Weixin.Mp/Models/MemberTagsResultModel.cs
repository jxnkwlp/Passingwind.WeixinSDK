using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models
{
    public class MemberTagsResultModel : JsonResultModel
    {
        public string[] Tagid_List { get; set; }
    }
}
