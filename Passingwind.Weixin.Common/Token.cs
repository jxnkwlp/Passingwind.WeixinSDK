using System;

namespace Passingwind.Weixin.Common
{
    /// <summary>
    ///  表示token 
    /// </summary>
    public class Token
    {
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public DateTimeOffset ExpiresTime { get; set; }

        public bool IsExpired()
        {
            return ExpiresTime < DateTimeOffset.Now;
        }
    }
}
