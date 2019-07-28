using Passingwind.Weixin.MP.MessageHandlers;
using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    public class MusicResponseMessageContentModel : IResponseMessageContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }
        public string HQMusicUrl { get; set; }
        public string ThumbMediaId { get; set; }
    }
}