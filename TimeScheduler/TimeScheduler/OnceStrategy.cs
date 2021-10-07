using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class OnceStrategy : SchedulerStrategy       
    {
        public override string CalculateNextExecutionDate(string numDays, string currentTime, string dateTime)
        {
            return dateTime;
        }

        public override string SchedulerDescription(string currentDate, string dateTime, string startDate, string endDate, string numDays)
        {
            return string.Format(Global.ExecutionDescription,
               "Once", DateTime.Parse(dateTime).ToShortDateString(),
               DateTime.Parse(dateTime).ToShortTimeString(),
                startDate, endDate);
        }
    }
}
