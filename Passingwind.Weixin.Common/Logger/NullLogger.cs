using System;

namespace Passingwind.Weixin.Logger
{
    internal class NullLogger : ILogger
    {
        public void Log(LogLevel level, Exception exception, string message, params string[] args)
        {
            // Nothing TODO 
        }
    }
}
