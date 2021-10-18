using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class RecurringStrategy : SchedulerStrategy
    {
        
        public override string CalculateNextExecutionDate(string currentDate, GeneralConfiguration generalConfiguration)
        {

            return DateTime.Parse(currentDate).AddDays(Double.Parse(generalConfiguration.NumDays)).ToString();
            
        }

        public override string SchedulerDescription(string currentDate, GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration)
        {
            return string.Format(Global.ExecutionDescription, 
                Global.EveryDay, DateTime.Parse(currentDate).AddDays(Convert.ToDouble(generalConfiguration.NumDays)).ToShortDateString(),
                DateTime.Parse(currentDate).ToShortTimeString(),
                limitsConfiguration.StartDate, limitsConfiguration.EndDate);
        }
    }
}
