using Passingwind.Weixin.Extensions;
using Passingwind.Weixin.MP.MessageHandlers;
using System;

namespace Passingwind.Weixin.MP.Models.Message
{
    /// <summary>
    ///  表示返回的消息
    /// </summary>
    public class ResponseMessageModel : IResponseMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public long CreateTime { get; set; }
        public string MsgType { get; set; }

        public IResponseMessageContent Content { get; set; }

        public ResponseMessageModel()
        {
            this.CreateTime = DateTime.Now.ToUnixTimeSeconds();
        }
    }

}