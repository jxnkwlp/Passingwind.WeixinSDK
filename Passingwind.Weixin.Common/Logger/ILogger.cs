using System;

namespace Passingwind.Weixin.Logger
{
    /// <summary>
    ///  默认 logger 
    /// </summary>
    public interface ILogger
    {
        void Log(string category, LogLevel level, Exception exception, string message, params string[] args);
    }

    public enum LogLevel
    {
        Error,
        Warn,
        Info,
        Debug,
        Trace,
    }
}
