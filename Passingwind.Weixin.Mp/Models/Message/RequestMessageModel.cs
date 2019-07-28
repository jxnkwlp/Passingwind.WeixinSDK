using Passingwind.Weixin.MP.MessageHandlers;
using System;

namespace Passingwind.Weixin.MP.Models.Message
{
    /// <summary>
    ///  请求的消息基础数据
    /// </summary>
    [Serializable]
    public abstract class RequestMessageModel : IRequestMessage
    {
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        ///   开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        ///  发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        ///  消息创建时间 (时间戳)
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        ///  消息类型
        /// </summary>
        public string MsgType { get; set; }

    }
}