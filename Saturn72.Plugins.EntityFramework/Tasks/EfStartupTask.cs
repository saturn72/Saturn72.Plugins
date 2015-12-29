using Saturn72.Core.Configuration;
using Saturn72.Core.Infrastructure;
using Saturn72.Core.Tasks;
using Saturn72.Extensions;

namespace Saturn72.Core.Data.Tasks
{
    public class EfStartupTask : IStartupTask
    {
        public int Order => -100;

        public void Execute()
        {
            var settings = SettingsLoader.LoadSettings<DataSettings>();
            if (settings == null || !settings.IsValid()) return;

            var provider = EngineContext.Current.Resolve<BaseDataProvider>();
            Guard.NotNull(provider, () => { throw new Saturn72Exception("No IDataProvider found"); });
            provider.SetDatabaseInitializer();
        }
    }
}