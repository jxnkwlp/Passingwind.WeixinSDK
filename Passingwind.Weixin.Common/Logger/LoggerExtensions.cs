using System;

namespace Passingwind.Weixin.Logger
{
    public static class LoggerExtensions
    {
        public static void Fatal(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Fatal, null, message, args);
        }

        public static void Fatal(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Info, exception, message, args);
        }

        public static void Error(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Error, null, message, args);
        }

        public static void Error(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Error, exception, message, args);
        }

        public static void Warn(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Warn, null, message, args);
        }

        public static void Warn(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Warn, exception, message, args);
        }

        public static void Info(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Info, null, message, args);
        }

        public static void Info(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Info, exception, message, args);
        }

        public static void Debug(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Debug, null, message, args);
        }

        public static void Debug(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Debug, exception, message, args);
        }

        public static void Trace(this ILogger logger, string message, params string[] args)
        {
            logger.Log(LogLevel.Trace, null, message, args);
        }

        public static void Trace(this ILogger logger, Exception exception, string message, params string[] args)
        {
            logger.Log(LogLevel.Trace, exception, message, args);
        }
    }
}
