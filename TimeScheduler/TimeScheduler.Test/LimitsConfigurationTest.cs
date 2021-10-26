using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    [TestClass]
    public class LimitsConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_start_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_execution_date_max_date()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "99999999";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

    }
}
