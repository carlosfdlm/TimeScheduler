namespace TimeScheduler
{
    public abstract class Execution
    {
        public Execution() { }

        public abstract string CalculateNextExecutionDate(GeneralConfiguration generalConfiguration);

        public abstract string SchedulerDescription(GeneralConfiguration generalConfiguration, LimitsConfiguration limitsConfiguration, DailyConfiguration dailyConfiguration, WeeklyConfiguration weeklyConfiguration);

    }
}
