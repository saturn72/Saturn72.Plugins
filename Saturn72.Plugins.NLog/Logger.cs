using System;
using System.Collections.Generic;
using Saturn72.Core;
using Saturn72.Core.Domain.Logging;
using Saturn72.Core.Domain.Users;

namespace Saturn72.Plugins.NLog
{
    public class Logger : ILogger
    {
        #region fields

        private readonly ILogWriter _logWriter;

        #endregion

        #region ctor

        public Logger(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        #endregion

        public bool IsEnabled(LogLevel level)
        {
            return true;
        }

        public void DeleteLog(Log log)
        {
            throw new NotSupportedException();
        }

        public IPagedList<Log> GetAllLogs(DateTime? fromUtc = null, DateTime? toUtc = null, string message = "",
            LogLevel? logLevel = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotSupportedException();
        }

        public Log GetLogById(object logId)
        {
            throw new NotSupportedException();
        }

        public IList<Log> GetLogByIds(int[] logIds)
        {
            throw new NotSupportedException();
        }

        public Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", User user=null)
        {
            var log = new Log
            {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                User = user,
                CreatedOnUtc = DateTime.UtcNow
            };

            _logWriter.Write(log);
            return log;
        }
    }
}