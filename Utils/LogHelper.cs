using NLog;

namespace REST_API.Utils
{
    public static class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public static void LogInfo(string message) => logger.Info(message);
    }
}
