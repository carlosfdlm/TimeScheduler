using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TimeScheduler.Test
{
    [TestClass]
    public class SchedulerTest
    {
        private const string DESCRIPTION = "Occurs {0}. Schedule will be used on {1} at {2} starting on {3} and ending on {4}.";
        private Scheduler scheduler;


        [TestMethod]
        public void validate_enabled_null()
        {
            this.scheduler = new Scheduler();
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_false()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "false";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Other";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_max_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_min_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_max_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_min_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.CurrentDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Recurring";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Recurring";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.NumDays = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Recurring";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.NumDays = "mal_formato";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_less_than_zero()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Recurring";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.NumDays = "-1";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_max_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_min_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_max_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_min_value()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_execution_date_once()
        {
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Once";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = "01/01/2000 00:00:00";
            string[] execution = this.scheduler.GetNextExecution();
            Assert.AreEqual(execution[0], "01/01/2000 00:00:00");
            Assert.AreEqual(execution[1], string.Format(DESCRIPTION,
               "Once", DateTime.Parse(this.scheduler.ExecutionDate).ToShortDateString(),
               DateTime.Parse(this.scheduler.ExecutionDate).ToShortTimeString(),
                this.scheduler.StartDate, this.scheduler.EndDate));
        }

        [TestMethod]
        public void validate_next_execution_date_recurring()
        {            
            this.scheduler = new Scheduler();
            this.scheduler.Enabled = "true";
            this.scheduler.ExecutionType = "Recurring";
            this.scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.NumDays = "1";
            this.scheduler.StartDate = "01/01/2000 00:00:00";
            this.scheduler.EndDate = "01/01/2000 00:00:00";
            string[] execution = this.scheduler.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], string.Format(DESCRIPTION,
                "every day", DateTime.Parse(this.scheduler.CurrentDate).AddDays(1).ToShortDateString(),
               DateTime.Parse(this.scheduler.CurrentDate).ToShortTimeString(),
                this.scheduler.StartDate, this.scheduler.EndDate));
        }
    }
}
