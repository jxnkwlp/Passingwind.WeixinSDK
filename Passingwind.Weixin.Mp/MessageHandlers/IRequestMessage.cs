using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public interface IRequestMessage
    {
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        long MsgId { get; set; }

        /// <summary>
        ///   开发者微信号
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        ///  发送方帐号（一个OpenID）
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        ///  消息创建时间 (时间戳)
        /// </summary>
        long CreateTime { get; set; }

        /// <summary>
        ///  消息类型
        /// </summary>
        string MsgType { get; set; }
    }
}
