using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class OnceStrategy : SchedulerStrategy       
    {
        public override string CalculateNextExecutionDate(string currentTime, GeneralConfiguration generalConfiguration)
        {
            return generalConfiguration.ExecutionDate;
        }

        public override string SchedulerDescription(string currentDate, GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration)
        {
            return string.Format(Global.ExecutionDescription,
               "Once", DateTime.Parse(generalConfiguration.ExecutionDate).ToShortDateString(),
               DateTime.Parse(generalConfiguration.ExecutionDate).ToShortTimeString(),
                limitsConfiguration.StartDate, limitsConfiguration.EndDate);
        }
    }
}
