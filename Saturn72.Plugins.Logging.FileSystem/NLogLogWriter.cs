using System;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using Saturn72.Core.Domain.Logging;
using Saturn72.Extensions;
using LogLevel = NLog.LogLevel;
using NLogLogger = NLog.Logger;

namespace Automation.Plugins.Logging
{
    public class NLogLogWriter : ILogWriter
    {
        protected const string LoggerName = "Saturn72 File System Logger";
        private NLogLogger _nlogLogger;

        protected virtual NLogLogger Logger => _nlogLogger ?? (_nlogLogger = InitLogger());

        public virtual void Write(Log log)
        {
            var message = string.Format("{0} >> On node: {1} >> Full Details: {2}", log.ShortMessage, log.FullMessage);

            Logger.Log(ToNLogLogLevel(log.LogLevel), message);
        }

        protected virtual NLogLogger InitLogger()
        {
            var wrapper = new AsyncTargetWrapper
            {
                Name = typeof (AsyncTargetWrapper).Name,
                QueueLimit = 10000,
                WrappedTarget = LoadTarget(),
                OverflowAction = AsyncTargetWrapperOverflowAction.Grow
            };
            SimpleConfigurator.ConfigureForTargetLogging(wrapper);
            LogManager.Configuration.LoggingRules.ForEachItem(lr => lr.EnableLoggingForLevel(LogLevel.Trace));
            LogManager.ReconfigExistingLoggers();

            return LogManager.GetLogger(LoggerName);
        }

        protected virtual Target LoadTarget()
        {
            var fileName = "${basedir}/logs/" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log";

            return new FileTarget
            {
                Layout = "${longdate} ${logger} ${level} - ${message}",
                FileName = fileName,
                KeepFileOpen = false,
                CreateDirs = true,
                Encoding = Encoding.UTF8,
                Name = typeof (FileTarget).Name
            };
        }

        protected virtual LogLevel ToNLogLogLevel(Saturn72.Core.Domain.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Saturn72.Core.Domain.Logging.LogLevel.Debug:
                    return LogLevel.Debug;
                case Saturn72.Core.Domain.Logging.LogLevel.Information:
                    return LogLevel.Info;
                case Saturn72.Core.Domain.Logging.LogLevel.Warning:
                    return LogLevel.Warn;
                case Saturn72.Core.Domain.Logging.LogLevel.Error:
                    return LogLevel.Error;
                case Saturn72.Core.Domain.Logging.LogLevel.Fatal:
                    return LogLevel.Fatal;
                default:
                    return LogLevel.Trace;
            }
        }
    }
}