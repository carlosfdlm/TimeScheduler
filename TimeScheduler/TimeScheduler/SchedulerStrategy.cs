namespace TimeScheduler
{
    public interface ISchedulerStrategy
    {
        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration);
    }
}
