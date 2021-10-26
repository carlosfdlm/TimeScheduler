using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    [TestClass]
    public class DailyConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_next_daily_configuration_occurs_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "none";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "false";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_once_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_times_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }


        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = string.Empty;
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_every_mode_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_end_time_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_starting_time_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "none";
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

        [TestMethod]
        public void validate_next_daily_configuration_occurs_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = string.Empty;
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_false()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "false";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "false";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_daily_configuration_occurs_true()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }
    }
}
