using Passingwind.Weixin.Extensions;
using System;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public class ResponseMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public long CreateTime { get; set; }
        public ResponseMessageType MsgType { get; set; }

        public ResponseMessage()
        {
            this.CreateTime = DateTime.Now.ToUnixTimeSeconds();
        }
    }

    public enum ResponseMessageType
    {
        Text,
        Image,
        Voice,
        Video,
        Music,
        News,
    }
}