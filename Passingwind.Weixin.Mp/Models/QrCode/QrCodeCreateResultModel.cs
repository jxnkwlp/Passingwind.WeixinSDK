using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.QrCode
{
    public class QrCodeCreateResultModel : JsonResultModel
    {
        public string Ticket { get; set; }
        public int Expire_Seconds { get; set; }
        public string Url { get; set; }
    }
}
