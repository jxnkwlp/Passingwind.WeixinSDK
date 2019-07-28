using System;

namespace Passingwind.Weixin
{
    /// <summary>
    ///  异常
    /// </summary>
    public class WeixinException : Exception
    {
        public WeixinException()
        {
        }

        public WeixinException(string message) : base(message)
        {
        }

        public WeixinException(string message, Exception exception) : base(message, exception)
        {
        }

    }
}
