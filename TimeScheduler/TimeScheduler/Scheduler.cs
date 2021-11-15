namespace TimeScheduler
{
    public class Scheduler
    {
        private string[] execution;
        private readonly SchedulerConfiguration schedulerConfiguration;

        public Scheduler(SchedulerConfiguration schedulerConfiguration) 
        {
            this.execution = new string[2];
            this.schedulerConfiguration = schedulerConfiguration;
        }

        private ISchedulerStrategy Strategy { get; set; }

        public string[] GetNextExecution()
        {
            this.Validate(this.schedulerConfiguration);
            execution = this.Strategy.CalculateNextDate(this.schedulerConfiguration);
            return execution;
        }

        private void Validate(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateEnabled(schedulerConfiguration.Enabled);
            this.ValidateStrategy(schedulerConfiguration.ExecutionType);
        }

        private void ValidateStrategy(ExecutionType executionType)
        {
            this.Strategy = executionType == ExecutionType.Once ? new OnceStrategy()
                : new RecurringStrategy();
        }

        private static void ValidateEnabled(bool? enabled)
        {
            if (enabled.Value == false)
            {
                throw new TimeSchedulerException("Enabled is false.");
            }
        }

    }
}
