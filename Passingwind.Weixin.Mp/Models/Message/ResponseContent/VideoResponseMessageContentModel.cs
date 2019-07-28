using Passingwind.Weixin.MP.MessageHandlers;
using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    public class VideoResponseMessageContentModel : IResponseMessageContent
    {
        public string MediaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}