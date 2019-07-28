using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.MP.Models.Media
{
    public class GetJsSDKMediaResultModel : JsonResultModel
    {
        /// <summary>
        ///  文件内容
        /// </summary>
        public byte[] Data { get; set; }
    }
}
