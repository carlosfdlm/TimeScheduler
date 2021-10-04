using System;

namespace TimeScheduler
{
    public abstract class SchedulerStrategy
    {
        public abstract DateTime? CalculateNextExecutionDate(double numDays, DateTime? currentDate, DateTime? dateTime);

        public abstract string SchedulerDescription(DateTime? currentDate, DateTime? startDate, DateTime? endDate);
    }
}
