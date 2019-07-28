using Passingwind.Weixin.MP.MessageHandlers;

namespace Passingwind.Weixin.MP.Models.Message
{
    public class TextResponseMessageContentModel : IResponseMessageContent
    {
        public string Content { get; set; }
    }
}