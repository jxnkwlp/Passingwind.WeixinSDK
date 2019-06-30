using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class BatchGetMaterialRequestModel
    {
        public MediaType Type { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
