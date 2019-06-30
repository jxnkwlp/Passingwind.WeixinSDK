using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class UpdateNewsRequestModel
    {
        public string Media_Id { get; set; }

        public int Index { get; set; }

        public AddMaterialNewsArticleItemRequestModel Articles { get; set; }
    }
}
