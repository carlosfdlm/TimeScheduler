using System;

namespace TimeScheduler
{
    public class SchedulerController
    {
        private Scheduler scheduler;
        string[] execution;

        public SchedulerController(Scheduler scheduler)
        {
            this.scheduler = scheduler;
            this.execution = new string[2];
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
            execution[0] = this.CalculateNextExecutionDate();
            execution[1] = this.SchedulerDescription();
            return execution;
        }

        private string CalculateNextExecutionDate()
        {
            return this.Scheduler.SchedulerStrategy.CalculateNextExecutionDate(this.scheduler.CurrentDate, this.Scheduler.GeneralConfiguration);
        }

        private string SchedulerDescription()
        {
            return this.Scheduler.SchedulerStrategy.SchedulerDescription(this.scheduler.CurrentDate, this.Scheduler.GeneralConfiguration, this.Scheduler.LimitsConfiguration);
        }

        public void ValidateFields()
        {
            this.ValidateEnabled();
            this.ValidateExecutionType();
            this.ValidateCurrentDate();
            if (this.scheduler.GeneralConfiguration.ExecutionType == "Once")
            {
                this.ValidateTimeExecution();
            }
            else
            {
                this.ValidateNumDays();
                this.ValidateSum();
            }
            this.ValidateStartDate();
            this.ValidateEndDate();
        }

        private void ValidateSum()
        {
            try
            {
                DateTime.Parse(this.scheduler.CurrentDate).AddDays(Double.Parse(this.scheduler.GeneralConfiguration.NumDays));
            }
            catch (Exception)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateStartDate()
        {
            this.ValidateDates(this.scheduler.LimitsConfiguration.StartDate);
        }

        private void ValidateCurrentDate()
        {
            this.ValidateDates(this.scheduler.CurrentDate);
        }

        private void ValidateTimeExecution()
        {
            this.ValidateDates(this.scheduler.GeneralConfiguration.ExecutionDate);
        }

        private void ValidateEndDate()
        {
            this.ValidateDates(this.scheduler.LimitsConfiguration.EndDate);
        }

        private void ValidateExecutionType()
        {
            if (this.scheduler.GeneralConfiguration.ExecutionType == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.scheduler.GeneralConfiguration.ExecutionType.ToString()))
            {
                throw new TimeSchedulerException();
            }
            if (this.scheduler.GeneralConfiguration.ExecutionType.ToString().Equals("Once") == false &&
               this.scheduler.GeneralConfiguration.ExecutionType.ToString().Equals("Recurring") == false)
            {
                throw new TimeSchedulerException();
            }
            this.Scheduler.SchedulerStrategy = this.scheduler.GeneralConfiguration.ExecutionType == "Once" ? new OnceStrategy()
                : new RecurringStrategy();
        }

        private void ValidateNumDays()
        {
            if (this.scheduler.GeneralConfiguration.NumDays == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrWhiteSpace(this.scheduler.GeneralConfiguration.NumDays))
            {
                throw new TimeSchedulerException();
            }
            if (Double.TryParse(this.scheduler.GeneralConfiguration.NumDays, out _) == false)
            {
                throw new TimeSchedulerException();
            }
            if (Double.Parse(this.scheduler.GeneralConfiguration.NumDays) < 0)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateDates(string DateToValidate)
        {
            if (DateToValidate == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrWhiteSpace(DateToValidate))
            {
                throw new TimeSchedulerException();
            }
            if (DateTime.TryParse(DateToValidate, out _) == false)
            {
                throw new TimeSchedulerException();
            }

        }

        private void ValidateEnabled()
        {
            if (this.scheduler.GeneralConfiguration.Enabled == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.scheduler.GeneralConfiguration.Enabled))
            {
                throw new TimeSchedulerException();
            }
            if (this.scheduler.GeneralConfiguration.Enabled.Equals("false") == false &&
                this.scheduler.GeneralConfiguration.Enabled.Equals("true") == false)
            {
                throw new TimeSchedulerException();
            }
            if (this.scheduler.GeneralConfiguration.Enabled.Equals("false"))
            {
                throw new TimeSchedulerException();
            }
        }

    }
}
