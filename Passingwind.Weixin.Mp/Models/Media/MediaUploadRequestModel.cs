using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class MediaUploadRequestModel
    {
        public MediaType Type { get; set; }

        public UploadFileModel Media { get; set; }
    } 
}
