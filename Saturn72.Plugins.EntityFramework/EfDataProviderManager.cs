using Saturn72.Extensions;

namespace Saturn72.Core.Data
{
    public class EfDataProviderManager : BaseDataProviderManager
    {
        protected override BaseDataProvider LoadDataProvider()
        {
            var providerName = DataSettings.DataProvider;
            Guard.MustFollow(providerName.HasValue(),
                () => { throw new Saturn72Exception("Data Settings is missing ProviderName"); });

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                default:
                    throw new Saturn72Exception(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }
    }
}