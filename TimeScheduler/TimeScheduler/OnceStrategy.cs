using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class OnceStrategy : ISchedulerStrategy
    {
        private readonly string[] nextDate;

        public OnceStrategy()
        {
            this.nextDate = new string[2];
        }

        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration)
        {
            this.nextDate[0] = CalculateNextExecutionDate(schedulerConfiguration);
            this.nextDate[1] = SchedulerDescription(schedulerConfiguration);
            return this.nextDate;
        }

        private static string CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.ExecutionDate.ToShortDateString();
        }

        private static string SchedulerDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                Global.ExecutionDescription,
                "Once",
                schedulerConfiguration.ExecutionDate.ToShortDateString(),
                schedulerConfiguration.ExecutionDate.ToShortTimeString(),
                schedulerConfiguration.StartDate,
                schedulerConfiguration.EndDate);
        }
    }
}
