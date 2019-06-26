using System;

namespace Passingwind.Weixin.Logger
{
    public class LoggerManager
    {
        static ILogger _logger = new NullLogger();

        public static void SetLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public static ILogger GetLogger()
        {
            return _logger;
        }

    }
}
