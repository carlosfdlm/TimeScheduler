using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    class OnceStrategy : SchedulerStrategy       
    {
        public override DateTime? CalculateNextExecutionDate(double numDays, DateTime? currentTime, DateTime? dateTime)
        {
            return dateTime.Value;
        }

        public override string SchedulerDescription(DateTime? dateTime, DateTime? startDate, DateTime? endDate)
        {
            return string.Format(Global.ExecutionDescription,
                ExecutionType.Recurring.ToString(), dateTime.Value.ToShortDateString(), dateTime.Value.ToShortTimeString(),
                startDate.Value.ToShortDateString(), endDate.Value.ToShortDateString());
        }
    }
}
