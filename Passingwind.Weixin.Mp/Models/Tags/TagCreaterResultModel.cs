using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    public class TagCreaterResultModel : JsonResultModel
    {
        public UserTagModel Tag { get; set; }

    }

    public class UserTagModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
