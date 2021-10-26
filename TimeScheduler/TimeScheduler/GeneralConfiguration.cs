using System;

namespace TimeScheduler
{
    public class GeneralConfiguration
    {
        public GeneralConfiguration() { }

        public string CurrentDate { get; set; }
        public string ExecutionDate { get; set; }
        public string Enabled { get; set; }
        public string NumDays { get; set; }
        public string ExecutionType { get; set; }


        public void Validate()
        {
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
        }
       
        public void ValidateEnabled()
        {
            if (this.Enabled == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.Enabled))
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

        public Execution ValidateExecutionType()
        {
            if (this.ExecutionType == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.ExecutionType.ToString()))
            {
                throw new TimeSchedulerException();
            }
            if (this.ExecutionType.ToString().Equals("Once") == false &&
               this.ExecutionType.ToString().Equals("Recurring") == false)
            {
                throw new TimeSchedulerException();
            }
            return this.ExecutionType == "Once" ? new OnceExecution()
                : new RecurringExecution();
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

        private void ValidateSum()
        {
            try
            {
                DateTime.Parse(this.CurrentDate).AddDays(Double.Parse(this.NumDays));
            }
            catch (Exception)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateCurrentDate()
        {
            this.CurrentDate.ValidateDates();
        }

        private void ValidateTimeExecution()
        {
            this.ExecutionDate.ValidateDates();
        }
    }        
}
