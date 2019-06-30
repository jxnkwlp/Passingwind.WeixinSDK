using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.Mp.Models.Media
{
    public class GetJsSDKMediaResultModel : JsonResultModel
    {
        /// <summary>
        ///  文件内容
        /// </summary>
        public byte[] Data { get; set; }
    }
}
