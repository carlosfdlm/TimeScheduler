namespace TimeScheduler
{
    public class Scheduler
    {
        private SchedulerConfiguration schedulerConfiguration;
        string[] execution;


        public Scheduler() 
        {
            this.schedulerConfiguration = new SchedulerConfiguration();
            this.execution = new string[2];

        }

        private SchedulerStrategy Strategy { get; set; }                 

        public SchedulerConfiguration SchedulerConfiguration
        {
            get
            {
                return this.schedulerConfiguration;
            }
        }

        public string[] GetNextExecution()
        {
            this.Validate();
            execution = this.Strategy.CalculateNextDate(this.SchedulerConfiguration);
            return execution;
        }

        private void Validate()
        {
            this.ValidateEnabled();
            this.ValidateStrategy();
        }

        private void ValidateStrategy()
        {
            if (this.SchedulerConfiguration.ExecutionType == null)
            {
                throw new TimeSchedulerException("Execution type is null.");
            }
            if (string.IsNullOrEmpty(this.SchedulerConfiguration.ExecutionType.ToString()))
            {
                throw new TimeSchedulerException("Execution type is empty.");
            }
            if (this.SchedulerConfiguration.ExecutionType.ToString().Equals("Once") == false &&
               this.SchedulerConfiguration.ExecutionType.ToString().Equals("Recurring") == false)
            {
                throw new TimeSchedulerException("Execution type bad format.");
            }
            this.Strategy = this.SchedulerConfiguration.ExecutionType == "Once" ? new OnceStrategy()
                : new RecurringStrategy();
        }

        private void ValidateEnabled()
        {
            if (this.SchedulerConfiguration.Enabled == null)
            {
                throw new TimeSchedulerException("Enabled check null.");
            }
            if (string.IsNullOrEmpty(this.SchedulerConfiguration.Enabled))
            {
                throw new TimeSchedulerException("Enabled check empty.");
            }
            if (this.SchedulerConfiguration.Enabled.Equals("false") == false &&
                this.SchedulerConfiguration.Enabled.Equals("true") == false)
            {
                throw new TimeSchedulerException("Enabled check bad format.");
            }
            if (this.SchedulerConfiguration.Enabled.Equals("false"))
            {
                throw new TimeSchedulerException("Enabled check is not enabled.");
            }
        }
    }
}
