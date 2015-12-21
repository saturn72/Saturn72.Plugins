using Saturn72.Core.Domain.Tasks;

namespace Saturn72.Core.Data.Mapping.Tasks
{
    public class ScheduleTaskMap : EfEntityTypeConfiguration<ScheduleTask>
    {
        protected override void Initialize()
        {
            HasKey(x => x.Id);
            ToTable("ScheduleTask");
            Property(x => x.Type).IsRequired();
            Property(x => x.Name).IsRequired();
        }
    }
}