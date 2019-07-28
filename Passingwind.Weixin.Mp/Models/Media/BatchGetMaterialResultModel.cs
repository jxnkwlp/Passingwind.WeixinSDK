using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.Media
{
    public class BatchGetMaterialResultModel : JsonResultModel
    {
        public int Total_Count { get; set; }
        public int Item_Count { get; set; }

        public IList<BatchGetMaterialItemModel> Item { get; set; }
    }

    public class BatchGetMaterialItemModel
    {
        public string Media_Id { get; set; }

        public BatchGetMaterialItemContent Content { get; set; }

        public string update_time { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class BatchGetMaterialItemContent
    {
        public IList<MaterialNewsModel> News_Item { get; set; }
    }

    //public class MaterialNewsItemModel
    //{
    //    public string Title { get; set; }
    //    public string Thumb_Media_Id { get; set; }
    //    public string Author { get; set; }
    //    public string Digest { get; set; }
    //    public int Show_cover_pic { get; set; }
    //    public string Content { get; set; }
    //    public string Content_Source_Url { get; set; }
    //    public int Url { get; set; }
    //}
}
