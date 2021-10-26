namespace TimeScheduler
{
    public class SchedulerController
    {
        private Scheduler scheduler;
        string[] execution;

        public SchedulerController()
        {
            this.execution = new string[2];
            this.scheduler = new Scheduler();
        }

        public Scheduler Scheduler 
        {
            get
            {
                return this.scheduler;
            }
        }
       

        public string[] GetNextExecution()
        {
            this.ValidateFields();
            execution[0] = this.Scheduler.Execution.CalculateNextExecutionDate(this.Scheduler.GeneralConfiguration);
            execution[1] = this.Scheduler.Execution.SchedulerDescription(this.Scheduler.GeneralConfiguration, this.Scheduler.LimitsConfiguration, this.Scheduler.DailyConfiguration, this.Scheduler.WeeklyConfiguration);
            return execution;
        }

        private void ValidateFields()
        {
            this.Scheduler.GeneralConfiguration.ValidateEnabled();
            this.Scheduler.Execution = this.Scheduler.GeneralConfiguration.ValidateExecutionType();
            this.Scheduler.GeneralConfiguration.Validate();            
            this.Scheduler.LimitsConfiguration.Validate();

            if(this.Scheduler.Execution is RecurringExecution)
            {                
                this.Scheduler.DailyConfiguration.Validate();
                this.Scheduler.WeeklyConfiguration.Validate();
            }            
        }  
    }
}
