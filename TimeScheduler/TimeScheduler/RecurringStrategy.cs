using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    class RecurringStrategy : SchedulerStrategy
    {
        private DateTime? currentDateConsecutive { get; set; }
        
        public override DateTime? CalculateNextExecutionDate(double numDays, DateTime? currentDate, DateTime? dateTime)
        {
            if (this.currentDateConsecutive.HasValue)
            {
                this.currentDateConsecutive = this.currentDateConsecutive.Value.AddDays(numDays);
            }
            else
            {
                currentDate.Value.AddDays(numDays);
                this.currentDateConsecutive = currentDate;
            }
            return this.currentDateConsecutive;
        }

        public override string SchedulerDescription(DateTime? currentDate, DateTime? startDate, DateTime? endDate)
        {
            return string.Format(Global.ExecutionDescription, 
                Global.EveryDay, this.currentDateConsecutive.Value.ToShortDateString(), this.currentDateConsecutive.Value.ToShortTimeString(),
                startDate.Value.ToShortDateString(), endDate.Value.ToShortDateString());
        }
    }
}
