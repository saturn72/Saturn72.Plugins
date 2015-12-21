using Hangfire;
using Owin;
using Saturn72.Core.Data;
using Saturn72.Core.Infrastructure;
using Saturn72.Extensions;
using Saturn72.Web.Framework.Owin;

namespace Saturn72.Plugins.HangFire
{
    public class HangFireOwinConfigurar : IOwinConfigurar
    {
        public void Configure(IAppBuilder appBuilder)
        {
            var dataProviderManager = EngineContext.Current.Resolve<BaseDataProviderManager>();
            Guard.NotNull(dataProviderManager);
            var connectionString = dataProviderManager.DataSettings.DataConnectionString;

            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);
            appBuilder.UseHangfireDashboard();
        }

        public int Order => 100;
    }
}