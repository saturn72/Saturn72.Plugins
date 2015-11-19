using Autofac;
using Saturn72.Core.Domain.Logging;
using Saturn72.Core.Infrastructure;
using Saturn72.Core.Infrastructure.DependencyManagement;

namespace Automation.Plugins.Logging
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1000;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<NLogLogWriter>().As<ILogWriter>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}