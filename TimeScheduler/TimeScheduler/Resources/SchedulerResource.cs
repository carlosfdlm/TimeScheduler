using System.Globalization;

namespace TimeScheduler.Resources
{
    public class SchedulerResource
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public CultureInfo Culture { get; set; }
    }
}
