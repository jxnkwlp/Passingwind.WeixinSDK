using Passingwind.Weixin.MP.Models.Message;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    /// <summary>
    ///  消息上下文
    /// </summary>
    public class MessageContext
    {
        public string Body { get; private set; }

        public MessageType MessageType { get; }

        public MessageEventType? EventType { get; set; }

        public IRequestMessage Request { get; }

        public IResponseMessage Response { get; private set; }

        public MessageContext()
        {
        }

        public MessageContext(MessageType messageType, IRequestMessage request, string body, MessageEventType? eventType = null)
        {
            MessageType = messageType;
            Request = request;
            Body = body;
            EventType = eventType;
        }

        public void SetResponse(IResponseMessage response)
        {
            //if (this.MessageType == MessageType.Event)
            //{
            //    throw new WeixinException("事件无需设置Response");
            //}

            this.Response = response;
        }

    }
}
