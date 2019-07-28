using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.MP.Models.Media
{
    public class AddMaterialResultModel : JsonResultModel
    {
        public string Media_Id { get; set; }

        public string Url { get; set; }
    }
}
