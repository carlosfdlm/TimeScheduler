using System;

namespace TimeScheduler
{
    public class RecurringExecution : Execution
    {
        private const string DESCRIPTION = "Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.";

        public RecurringExecution() { }

        public override string CalculateNextExecutionDate(GeneralConfiguration generalConfiguration)
        {
            return DateTime.Parse(generalConfiguration.CurrentDate).AddDays(Double.Parse(generalConfiguration.NumDays)).ToString();
        }

        public override string SchedulerDescription(GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration, DailyConfiguration dailyConfiguration, WeeklyConfiguration weeklyConfiguration)
        {
            return string.Format(DESCRIPTION,
                weeklyConfiguration.EveryTimes,
                weeklyConfiguration.WeekDaysMsg(),
                dailyConfiguration.TypeStr,
                dailyConfiguration.StartTime,
                dailyConfiguration.EndTime,
                limitsConfiguration.StartDate, 
                limitsConfiguration.EndDate);
        }
    }
}
