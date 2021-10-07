using System;

namespace TimeScheduler
{
    public abstract class SchedulerStrategy
    {
        public abstract string CalculateNextExecutionDate(string numDays, string currentDate, string dateTime);

        public abstract string SchedulerDescription(string currentDate, string executionDate, string startDate, string endDate, string numDays);
    }
}
