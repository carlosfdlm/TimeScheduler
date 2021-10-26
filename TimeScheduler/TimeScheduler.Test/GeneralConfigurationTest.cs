using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    [TestClass]
    public class GeneralConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_enabled_null()
        {
            this.schedulerController = new SchedulerController();
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "bad_format";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_enabled_false()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "false";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_type_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Other";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_current_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "144/188/1000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/10000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_execution_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/0000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "mal_formato";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_num_days_less_than_zero()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "-1";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

    }
}
