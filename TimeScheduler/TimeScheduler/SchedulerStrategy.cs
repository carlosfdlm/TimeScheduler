namespace TimeScheduler
{
    public interface SchedulerStrategy
    {
        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration);

    }
}
