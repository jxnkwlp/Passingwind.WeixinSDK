using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models
{
    public class TagListResultModel : JsonResultModel
    {
        public UserTag[] Tags { get; set; }

        public class UserTag
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Count { get; set; }
        }

    }
}
