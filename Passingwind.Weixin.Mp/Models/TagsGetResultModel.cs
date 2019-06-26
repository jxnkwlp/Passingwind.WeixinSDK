using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.Mp.Models
{
    public class TagsGetResultModel : JsonResultModel
    {
        public int Count { get; set; }

        public OpenIdData Data { get; set; }

        public string Next_Openid { get; set; }

        public class OpenIdData
        {
            public string[] Openid { get; set; }
        } 
    }
}
