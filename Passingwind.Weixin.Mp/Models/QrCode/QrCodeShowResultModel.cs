using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.QrCode
{
    public class QrCodeShowResultModel : JsonResultModel
    {
        public byte[] File { get; set; }
    }
}
