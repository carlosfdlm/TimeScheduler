using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class OnceStrategy : SchedulerStrategy
    {
        private string[] nextDate;

        public OnceStrategy()
        {
            this.nextDate = new string[2];
        }

        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration)
        {
            this.ValidateCurrentDate(schedulerConfiguration.CurrentDate);
            this.ValidateTimeExecution(schedulerConfiguration.ExecutionDate);
            this.ValidateLimits(schedulerConfiguration.StartDate, schedulerConfiguration.EndDate);
            this.nextDate[0] = this.CalculateNextExecutionDate(schedulerConfiguration);
            this.nextDate[1] = this.SchedulerDescription(schedulerConfiguration);
            return this.nextDate;
        }

        private string CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.ExecutionDate;
        }

        private string SchedulerDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(Global.ExecutionDescription,
              "Once", DateTime.Parse(schedulerConfiguration.ExecutionDate).ToShortDateString(),
              DateTime.Parse(schedulerConfiguration.ExecutionDate).ToShortTimeString(),
               schedulerConfiguration.StartDate, schedulerConfiguration.EndDate);
        }

        private void ValidateLimits(string startDate, string endDate)
        {
            try
            {
                startDate.ValidateDates();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("Start date " + exc.Message);
            }
            try
            {
                endDate.ValidateDates();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("End date " + exc.Message);
            }                       
        }

        private void ValidateTimeExecution(string executionDate)
        {
            try
            {
                executionDate.ValidateDates();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("Execution date " + exc.Message);
            }
        }

        private void ValidateCurrentDate(string currentDate)
        {
            try
            {
                currentDate.ValidateDates();
            }
            catch(TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("Current date " + exc.Message);
            }
        }
    }
}
