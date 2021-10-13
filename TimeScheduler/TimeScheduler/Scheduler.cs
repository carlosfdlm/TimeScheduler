using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class Scheduler
    {
        string[] execution;

        public Scheduler()
        {
            this.execution = new string[2];
        }

        public string CurrentDate { get; set; }
        public string ExecutionDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Enabled { get; set; }
        public string NumDays { get; set; }
        public string ExecutionType { get; set; }

        public SchedulerStrategy SchedulerStrategy { get; set; }

        public string[] GetNextExecution()
        {
            this.ValidateFields();
            execution[0] = this.CalculateNextExecutionDate();
            execution[1] = this.SchedulerDescription();
            return execution;
        }

        private string CalculateNextExecutionDate()
        {
            return this.SchedulerStrategy.CalculateNextExecutionDate(this.NumDays, this.CurrentDate, this.ExecutionDate);
        }

        private string SchedulerDescription()
        {
            return this.SchedulerStrategy.SchedulerDescription(this.CurrentDate, this.ExecutionDate, this.StartDate, this.EndDate, this.NumDays);
        }

        public void ValidateFields()
        {
            this.ValidateEnabled();
            this.ValidateExecutionType();
            this.ValidateCurrentDate();            
            if (this.ExecutionType == "Once")
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
                DateTime.Parse(this.CurrentDate).AddDays(Double.Parse(this.NumDays));
            }
            catch(Exception e)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateStartDate()
        {
            this.ValidateDates(this.StartDate);
        }

        private void ValidateCurrentDate()
        {
            this.ValidateDates(this.CurrentDate);
        }

        private void ValidateTimeExecution()
        {
            this.ValidateDates(this.ExecutionDate);
        }

        private void ValidateEndDate()
        {
            this.ValidateDates(this.EndDate);
        }

        private void ValidateExecutionType()
        {
            if (this.ExecutionType == null)
            {
                throw new TimeSchedulerException(Global.DateTimeNotCompleted);
            }
            if (string.IsNullOrEmpty(this.ExecutionType.ToString()))
            {
                throw new TimeSchedulerException(Global.DateTimeNotCompleted);
            }
            if (this.ExecutionType.ToString().Equals("Once") == false &&
               this.ExecutionType.ToString().Equals("Recurring") == false)
            {
                throw new TimeSchedulerException(Global.DateTimeNotCompleted);
            }
            this.SchedulerStrategy = this.ExecutionType == "Once" ? new OnceStrategy()
                : new RecurringStrategy();
        }

        private void ValidateNumDays()
        {
            if (this.NumDays == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrWhiteSpace(this.NumDays))
            {
                throw new TimeSchedulerException();
            }
            if (Double.TryParse(this.NumDays, out _) == false)
            {
                throw new TimeSchedulerException();
            }
            if (Double.Parse(this.NumDays) < 0)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateDates(string DateToValidate)
        {
            if (DateToValidate == null)
            {
                throw new TimeSchedulerException(Global.DateTimeNotCompleted);
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
            if (this.Enabled == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(Enabled))
            {
                throw new TimeSchedulerException();
            }
            if (this.Enabled.Equals("false") == false &&
                this.Enabled.Equals("true") == false)
            {
                throw new TimeSchedulerException();
            }
            if (this.Enabled.Equals("false"))
            {
                throw new TimeSchedulerException();
            }
        }

    }
}
