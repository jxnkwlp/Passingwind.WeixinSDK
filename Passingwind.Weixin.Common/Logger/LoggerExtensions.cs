using System;

namespace Passingwind.Weixin.Logger
{
    public static class LoggerExtensions
    {
        public static void Error(this ILogger logger, string category, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Error, null, message, args);
        }

        public static void Error(this ILogger logger, string category, Exception exception, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Error, exception, message, args);
        }

        public static void Warn(this ILogger logger, string category, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Warn, null, message, args);
        }

        public static void Warn(this ILogger logger, string category, Exception exception, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Warn, exception, message, args);
        }

        public static void Info(this ILogger logger, string category, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Info, null, message, args);
        }

        public static void Info(this ILogger logger, string category, Exception exception, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Info, exception, message, args);
        }

        public static void Debug(this ILogger logger, string category, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Debug, null, message, args);
        }

        public static void Debug(this ILogger logger, string category, Exception exception, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Debug, exception, message, args);
        }

        public static void Trace(this ILogger logger, string category, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Trace, null, message, args);
        }

        public static void Trace(this ILogger logger, string category, Exception exception, string message, params string[] args)
        {
            logger.Log(category, LogLevel.Trace, exception, message, args);
        }
    }
}
