using Passingwind.Weixin.MP.MessageHandlers;
using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    public class ImageResponseMessageContentModel : IResponseMessageContent
    {
        public string MediaId { get; set; }
    }
}