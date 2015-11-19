using Saturn72.Core.Domain.Logging;

namespace Automation.Plugins.Logging
{
    public interface ILogWriter
    {
        void Write(Log log);
    }
}