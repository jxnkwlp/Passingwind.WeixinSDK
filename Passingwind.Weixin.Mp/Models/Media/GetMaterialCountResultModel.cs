using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class GetMaterialCountResultModel : JsonResultModel
    {
        public int Voice_Count { get; set; }
        public int Video_Count { get; set; }
        public int Image_Count { get; set; }
        public int News_Count { get; set; }
    }
}
