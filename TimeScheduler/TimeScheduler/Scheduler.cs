using System;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public class Scheduler
    {
        private DateTime currentDate;
        private DateTime? dateExecution;
        private DateTime? startDate;
        private DateTime? endDate;
        private DateTime nextExecutionTime;
        private string executionDescription;
        private bool enabled;
        private int numDays;
        private ExecutionType executionType;
        private SchedulerStrategy schedulerStrategy;

        public Scheduler(SchedulerStrategy schedulerStrategy)
        {
            this.schedulerStrategy = schedulerStrategy;
        }

        public DateTime CurrentDate { get; set; }
        public DateTime? DateExecution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Enabled { get; set; }
        public double NumDays { get; set; }
       
        public string CalculateNextExecutionDate()
        {
            return this.schedulerStrategy.CalculateNextExecutionDate(this.NumDays, this.CurrentDate, this.DateExecution).Value.ToString();
        }

        public string SchedulerDescription()
        {
            return this.schedulerStrategy.SchedulerDescription(this.DateExecution, this.StartDate, this.EndDate);
        }

        internal void ValidateFields(DateTime dateTime, DateTime startDate)
        {
            if (dateTime.IsNull())
            {
                throw new Exception(Global.DateTimeNotCompleted);
            }
            if (startDate.IsNull())
            {
                throw new Exception(Global.StartDateNotCompleted);
            }
        }
    }
}
