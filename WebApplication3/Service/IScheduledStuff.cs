using Microsoft.Extensions.Caching.Memory;

namespace ElectronicsStore.Infrastructure
{
    public interface IScheduledStuff
    {
        void ScheduleItemsExecute();

    }
}