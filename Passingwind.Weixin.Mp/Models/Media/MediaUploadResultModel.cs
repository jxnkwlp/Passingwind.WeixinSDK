using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Media
{
    public class MediaUploadResultModel : JsonResultModel
    {
        public MediaType Type { get; set; }

        public string Media_Id { get; set; }

        public long Created_At { get; set; }
    }
}
