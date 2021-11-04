using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    public class LimitsConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_start_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "144/188/1000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/10000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_start_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/0000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "144/188/1000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_max_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/10000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_end_date_min_value()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/0000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_execution_date_max_date()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "99999999";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

    }
}
