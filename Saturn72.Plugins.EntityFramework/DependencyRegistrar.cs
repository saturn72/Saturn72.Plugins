using Autofac;
using Saturn72.Core.Infrastructure;
using Saturn72.Core.Infrastructure.DependencyManagement;
using Saturn72.Extensions;

namespace Saturn72.Core.Data
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 100; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<SqlServerDataProvider>().As<BaseDataProvider>().InstancePerDependency();

            builder.Register(x => new EfDataProviderManager()).As<BaseDataProviderManager>().InstancePerDependency();

            var dataProviderManager = new EfDataProviderManager();
            var dataSettings = dataProviderManager.DataSettings;

            Guard.MustFollow(() => dataSettings != null && dataSettings.IsValid(),
                () => { throw new Saturn72Exception("Failed to read DataSettings."); });

            var dataProvider = dataProviderManager.DataProvider;
            Guard.NotNull(dataProvider);
            dataProvider.SetDatabaseInitializer();

            var nameOrConnectionString = dataSettings.DataConnectionString.HasValue()
                ? dataSettings.DataConnectionString
                : dataSettings.DatabaseName;

            builder.Register<IDbContext>(c => new Saturn72ObjectContext(nameOrConnectionString))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof (EfRepository<>)).As(typeof (IRepository<>)).InstancePerLifetimeScope();
        }
    }
}