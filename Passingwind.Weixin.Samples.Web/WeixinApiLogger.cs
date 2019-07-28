using Passingwind.Weixin.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Samples.Web
{
    public class WeixinApiLogger : ILogger
    {
        NLog.Logger _logger = NLog.LogManager.GetLogger("weixin");

        public void Log(string category, LogLevel level, Exception exception, string message, params string[] args)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _logger.Debug(exception, $"[{category}]{message}", args);
                    break;
                case LogLevel.Error:
                    _logger.Error(exception, $"[{category}]{message}", args);
                    break;
                case LogLevel.Info:
                    _logger.Info(exception, $"[{category}]{message}", args);
                    break;
                case LogLevel.Warn:
                    _logger.Warn(exception, $"[{category}]{message}", args);
                    break;
                case LogLevel.Trace:
                    _logger.Trace(exception, $"[{category}]{message}", args);
                    break;
            }
        }
    }
}
