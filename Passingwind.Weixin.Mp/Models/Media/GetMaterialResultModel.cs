using Passingwind.Weixin.Models;
using System.Collections.Generic;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class GetMaterialResultModel : JsonResultModel
    {
        /// <summary>
        ///  图文素材
        /// </summary>
        public IList<MaterialNewsModel> News_Item { get; set; }

        /// <summary>
        ///  其他类型的素材消息，则为素材的内容
        /// </summary>
        public byte[] FileData { get; set; }

        /// <summary>
        ///  视频消息素材
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///  视频消息素材
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  视频消息素材
        /// </summary>
        public string Down_Url { get; set; }
    }

    //public class MaterialNewsItem
    //{
    //    public string Title { get; set; }
    //    public string Thumb_Media_Id { get; set; }
    //    public string Author { get; set; }
    //    public string Digest { get; set; }
    //    public string Content { get; set; }
    //    public string Url { get; set; }
    //    public string Content_Source_Url { get; set; }

    //    public int Need_Open_Comment { get; set; }
    //    public int Only_Fans_Can_Comment { get; set; }
    //}
}
