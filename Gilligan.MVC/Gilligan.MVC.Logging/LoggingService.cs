using System;
using Gilligan.MVC.DomainContracts;
using NLog;

namespace Gilligan.MVC.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public LoggingService()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget { FileName = "file.txt", Name = "logfile" };

            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));

            LogManager.Configuration = config;
        }

        public void Log(Exception e)
        {
            _logger.Log(LogLevel.Info, e);
        }
    }
}
