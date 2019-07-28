using System;

namespace Passingwind.Weixin.Logger
{
    public class NullLogger : ILogger
    {
        public void Log(string category, LogLevel level, Exception exception, string message, params string[] args)
        {
            // Nothing TODO 
        }
    }
}
