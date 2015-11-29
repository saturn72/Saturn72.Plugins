using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Saturn72.Core.Data.Initializers;

namespace Saturn72.Core.Data
{
    public class SqlServerDataProvider : BaseDataProvider
    {
        public override void SetDatabaseInitializer()
        {
            var initializer = new CreateDatabaseAndTableIfNotExists<Saturn72ObjectContext>(GetMandatoryTables(), GetSqlScripts());

            Database.SetInitializer(initializer);
        }

        private string[] GetSqlScripts()
        {
            return null;
        }

        private string[] GetMandatoryTables()
        {
            return new[]
            {
                "Setting",
                "LocaleStringResource"
            };
        }

        public override Type GetUnproxiedEntityType(BaseEntity entity)
        {
            var userType = ObjectContext.GetObjectType(entity.GetType());
            return userType;
        }
    }
}