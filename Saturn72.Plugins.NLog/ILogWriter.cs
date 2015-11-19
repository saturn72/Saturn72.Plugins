using Saturn72.Core.Domain.Logging;

namespace Saturn72.Plugins.NLog
{
    public interface ILogWriter
    {
        void Write(Log log);
    }
}