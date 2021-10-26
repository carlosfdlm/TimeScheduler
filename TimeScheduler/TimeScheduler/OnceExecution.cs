using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class OnceExecution : Execution
    {
        public OnceExecution() { }

        public override string CalculateNextExecutionDate(GeneralConfiguration generalConfiguration)
        {
            return generalConfiguration.ExecutionDate;
        }

        public override string SchedulerDescription(GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration, DailyConfiguration dailyConfiguration, WeeklyConfiguration weeklyConfiguration)
        {
            return string.Format(Global.ExecutionDescription,
              "Once", DateTime.Parse(generalConfiguration.ExecutionDate).ToShortDateString(),
              DateTime.Parse(generalConfiguration.ExecutionDate).ToShortTimeString(),
               limitsConfiguration.StartDate, limitsConfiguration.EndDate);
        }
    }
}
