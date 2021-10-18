using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TimeScheduler.Test
{
    [TestClass]
    public class SchedulerTest
    {
        private const string DESCRIPTION = "Occurs {0}. Schedule will be used on {1} at {2} starting on {3} and ending on {4}.";
        private SchedulerController schedulerController;


        [TestMethod]
        public void validate_enabled_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "bad_format";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_false()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "false";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Other";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_max_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_min_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_max_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_min_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "mal_formato";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_less_than_zero()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "-1";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_max_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_min_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_null()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_empty()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_bad_format()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_max_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_min_value()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_execution_date_once()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "01/01/2000 00:00:00");
            Assert.AreEqual(execution[1], string.Format(DESCRIPTION,
               "Once", DateTime.Parse(this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate).ToShortDateString(),
               DateTime.Parse(this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate).ToShortTimeString(),
                this.schedulerController.Scheduler.LimitsConfiguration.StartDate, this.schedulerController.Scheduler.LimitsConfiguration.EndDate));
        }

        [TestMethod]
        public void validate_next_execution_date_recurring()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], string.Format(DESCRIPTION,
                "every day", DateTime.Parse(this.schedulerController.Scheduler.CurrentDate).AddDays(1).ToShortDateString(),
               DateTime.Parse(this.schedulerController.Scheduler.CurrentDate).ToShortTimeString(),
                this.schedulerController.Scheduler.LimitsConfiguration.StartDate, this.schedulerController.Scheduler.LimitsConfiguration.EndDate));
        }

        [TestMethod]
        public void validate_next_execution_date_max_date()
        {
            this.schedulerController = new SchedulerController(new Scheduler());
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "99999999";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }     
    }
}
