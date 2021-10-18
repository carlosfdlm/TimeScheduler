using System;

namespace TimeScheduler
{
    public abstract class SchedulerStrategy
    {
        public abstract string CalculateNextExecutionDate(string currentDate, GeneralConfiguration generalConfiguration);

        public abstract string SchedulerDescription(string currentDate, GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration);
    }
}
