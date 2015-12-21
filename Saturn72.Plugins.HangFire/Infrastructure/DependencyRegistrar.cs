using Autofac;
using Hangfire;
using Saturn72.Core.Infrastructure;
using Saturn72.Core.Infrastructure.DependencyManagement;

namespace Saturn72.Plugins.HangFire.Infrastructure
{
    public class DependencyRegistrar:IDependencyRegistrar
    {
        public int Order => 100;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
          //  builder.RegisterType<TaskManager>().As<ITaskManager>().InstancePerLifetimeScope();
        }
    }
}
