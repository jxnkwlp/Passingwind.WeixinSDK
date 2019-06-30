using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class GetMediaResultModel : JsonResultModel
    {
        /// <summary>
        ///  如果是视频消息素材,则video_url有值
        /// </summary>
        public string Video_Url { get; set; }

        /// <summary>
        ///  其他类型,则为文件内容
        /// </summary>
        public byte[] Data { get; set; }
    }
}
