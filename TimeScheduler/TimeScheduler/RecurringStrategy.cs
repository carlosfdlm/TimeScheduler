using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class RecurringStrategy : SchedulerStrategy
    {
        
        public override string CalculateNextExecutionDate(string numDays, string currentDate, string dateTime)
        {

            return DateTime.Parse(currentDate).AddDays(Double.Parse(numDays)).ToString();
            
        }

        public override string SchedulerDescription(string currentDate, string executionDate, string startDate, string endDate, string numDays)
        {
            return string.Format(Global.ExecutionDescription, 
                Global.EveryDay, DateTime.Parse(currentDate).AddDays(1).ToShortDateString(),
                DateTime.Parse(currentDate).ToShortTimeString(),
                startDate, endDate);
        }
    }
}
