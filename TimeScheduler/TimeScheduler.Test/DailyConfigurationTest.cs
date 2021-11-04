using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    public class DailyConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_next_daily_configuration_occurs_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "none";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "false";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }


        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = string.Empty;
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "none";

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

        [TestMethod]
        public void validate_next_daily_configuration_occurs_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = string.Empty;
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_false()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "false";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "false";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_true()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }
    }
}
