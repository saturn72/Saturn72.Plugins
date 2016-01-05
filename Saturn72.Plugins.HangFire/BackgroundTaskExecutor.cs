using System;

namespace Saturn72.Modules.HangFire
{
    internal class BackgroundTaskExecutor
    {
        public void Execute<T>(Action<T> action, T t)
        {
            action(t);
        }

        public void Execute(Action action)
        {
            action();
        }
    }
}