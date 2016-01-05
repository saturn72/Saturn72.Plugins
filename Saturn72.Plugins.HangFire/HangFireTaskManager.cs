using System;
using Hangfire;
using Saturn72.Core.Services.Tasks;
using Saturn72.Extensions;

namespace Saturn72.Modules.HangFire
{
    public class HangFireTaskManager : ITaskManager
    {
        public void Initialize()
        {
        }

        public void Add(BackgroundTaskWrapperBase task)
        {
            Guard.NotNull(task);
            if (!task.CronExpression.HasValue())
            {
                if (task.DelayTimeSpan == default(TimeSpan))
                {
                    BackgroundJob.Enqueue(() => task.Execute());
                }
                else
                {
                    BackgroundJob.Schedule(() => task.Execute(), task.DelayTimeSpan);
                }
            }

            //TODO - Add recurring taskhere 
        }
    }
}