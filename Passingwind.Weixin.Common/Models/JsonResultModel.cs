using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Models
{
    /// <summary>
    ///  return basic model 
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("errcode:{ErrorCode}, errmsg:{ErrorMsg}")]
    public class JsonResultModel
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        ///  JSON Source
        /// </summary>
        public string JsonSource { get; set; }
    }
}
