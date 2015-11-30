using Saturn72.Core.Domain.Logging;

    namespace Saturn72.Core.Data.Mapping.Logging
{
    public class LogRecordMap:EfEntityTypeConfiguration<LogRecord>
    {
        protected override void Initialize()
        {
            ToTable("LogRecord");
            HasKey(s => s.Id);
        }
    }
}
